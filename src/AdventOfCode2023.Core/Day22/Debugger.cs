using System.IO;
using System.Text;
using static AdventOfCode2023.Core.Day22.Day22.PartShared;

namespace AdventOfCode2023.Core.Day22;

internal static partial class Day22 {

    internal static class Debugger {

        internal static void Print(Space3D space) {

           Print(space.Space);

        }

        internal static void Print(int[,,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        Console.WriteLine($"'[{i},{j},{k}]': {matrix[i, j, k]},");
                    }
                }
            }

        }

        internal static void GenerateThreeJSHTMLFile(Space3D space, string filePath = "visualization.html")
        {
            GenerateThreeJSHTMLFile(space.Space, filePath);
        }

        internal static void GenerateThreeJSHTMLFile(int[,,] matrix, string filePath = "visualization.html")
        {
            var sb = new StringBuilder();
            
            sb.AppendLine("const matrixData = {");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        sb.AppendLine($"  '[{i},{j},{k}]': {matrix[i, j, k]},");
                    }
                }
            }
            sb.AppendLine("};");

            // Build the complete HTML file
            var html = $@"<!DOCTYPE html>
<html>
<head>
    <title>3D Space Visualization</title>
    <style>
        body {{ margin: 0; overflow: hidden; }}
    </style>
</head>
<body>

<script src=""https://cdnjs.cloudflare.com/ajax/libs/three.js/r128/three.min.js""></script>

<script src=""https://cdn.jsdelivr.net/npm/three@0.128.0/examples/js/controls/OrbitControls.min.js""></script>

<script>

// ------------------------
// Data (your matrix)
// ------------------------
{sb}

const colorMap = {{
    1: 0xff0000, 2: 0x00ff00, 3: 0x0000ff,
    4: 0xffff00, 5: 0xff00ff, 6: 0x00ffff, 7: 0xff8800,
    8: 0x8800ff, 9: 0x00ff88, 10: 0xff0088,
    11: 0x0088ff, 12: 0x88ff00, 13: 0xff4444,
    14: 0x44ff44, 15: 0x4444ff
}};

// ------------------------
// Make Z the 'up' axis
// ------------------------
THREE.Object3D.DefaultUp.set(0, 0, 1); // global default up = Z
const scene = new THREE.Scene();
scene.background = new THREE.Color(0xf0f0f0);

// ------------------------
// Renderer & Camera
// ------------------------
const renderer = new THREE.WebGLRenderer({{ antialias: true }});
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

const camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.up.set(0,0,1); // ensure camera up = Z

// ------------------------
// Controls
// ------------------------
const controls = new THREE.OrbitControls(camera, renderer.domElement);
controls.enableDamping = true;
controls.dampingFactor = 0.08;
// allow full azimuthal rotation (around Z) but limit polar so camera stays above XY plane
controls.minPolarAngle = 0.05;
controls.maxPolarAngle = Math.PI / 2.05;

// ------------------------
// Build ground (XY plane) explicitly
// ------------------------
function makeXYGrid(size = 20, divisions = 20){{
    // create grid lines on Z=0 (XY plane)
    const grid = new THREE.Group();
    const step = size / divisions;
    const half = size / 2;
    const material = new THREE.LineBasicMaterial({{ color: 0xcccccc }});

    for(let i = -half; i <= half + 0.0001; i += step){{
        // lines parallel to X (varying Y)
        const points1 = [ new THREE.Vector3(-half, i, 0), new THREE.Vector3(half, i, 0) ];
        const geom1 = new THREE.BufferGeometry().setFromPoints(points1);
        grid.add(new THREE.Line(geom1, material));

        // lines parallel to Y (varying X)
        const points2 = [ new THREE.Vector3(i, -half, 0), new THREE.Vector3(i, half, 0) ];
        const geom2 = new THREE.BufferGeometry().setFromPoints(points2);
        grid.add(new THREE.Line(geom2, material));
    }}
    return grid;
}}
const grid = makeXYGrid(20, 20);
scene.add(grid);

// ------------------------
// Axes helper (visual) - will match our Z-up
// ------------------------
const axes = new THREE.AxesHelper(10);
scene.add(axes);

// ------------------------
// Compute bounds from data (used for axis ticks & labels)
// ------------------------
let minX=Infinity, maxX=-Infinity, minY=Infinity, maxY=-Infinity, minZ=Infinity, maxZ=-Infinity;
Object.keys(matrixData).forEach(k=>{{
    const [x,y,z] = JSON.parse(k);
    minX = Math.min(minX, x); maxX = Math.max(maxX, x);
    minY = Math.min(minY, y); maxY = Math.max(maxY, y);
    minZ = Math.min(minZ, z); maxZ = Math.max(maxZ, z);
}});
// add small margins
minX -= 1; minY -= 1; minZ = Math.max(0, minZ - 1);
maxX += 1; maxY += 1; maxZ += 1;

// ------------------------
// Axis numeric ticks & labels (ONLY on axes)
// ------------------------
function makeLabelSprite(text, size=32){{
    const canvas = document.createElement('canvas');
    const ctx = canvas.getContext('2d');
    ctx.font = `${{size}}px Arial`;
    const width = Math.ceil(ctx.measureText(text).width) + 10;
    canvas.width = width;
    canvas.height = size + 10;
    ctx.font = `${{size}}px Arial`;
    ctx.fillStyle = 'black';
    ctx.textBaseline = 'middle';
    ctx.fillText(text, 5, canvas.height/2);
    const tex = new THREE.CanvasTexture(canvas);
    const mat = new THREE.SpriteMaterial({{ map: tex, depthTest: false }});
    const spr = new THREE.Sprite(mat);
    // scale appropriate to world units
    spr.scale.set(canvas.width / 25, canvas.height / 25, 1);
    return spr;
}}

// ticks on X axis (Y=0,Z=0)
for(let x = Math.ceil(minX); x <= Math.floor(maxX); x++){{
    const tickGeom = new THREE.BufferGeometry().setFromPoints([
        new THREE.Vector3(x, -0.08, 0),
        new THREE.Vector3(x, 0.08, 0)
    ]);
    scene.add(new THREE.Line(tickGeom, new THREE.LineBasicMaterial({{ color:0x000000 }})));

    const lbl = makeLabelSprite(`${{x}}`, 28);
    lbl.position.set(x, -0.5, 0);
    scene.add(lbl);
}}

// ticks on Y axis (X=0,Z=0)
for(let y = Math.ceil(minY); y <= Math.floor(maxY); y++){{
    const tickGeom = new THREE.BufferGeometry().setFromPoints([
        new THREE.Vector3(-0.08, y, 0),
        new THREE.Vector3(0.08, y, 0)
    ]);
    scene.add(new THREE.Line(tickGeom, new THREE.LineBasicMaterial({{ color:0x000000 }})));

    const lbl = makeLabelSprite(`${{y}}`, 28);
    lbl.position.set(-0.5, y, 0);
    scene.add(lbl);
}}

// ticks on Z axis (X=0,Y=0) - vertical numbers
for(let z = Math.ceil(minZ); z <= Math.floor(maxZ); z++){{
    const tickGeom = new THREE.BufferGeometry().setFromPoints([
        new THREE.Vector3(-0.08, 0, z),
        new THREE.Vector3(0.08, 0, z)
    ]);
    scene.add(new THREE.Line(tickGeom, new THREE.LineBasicMaterial({{ color:0x000000 }})));

    const lbl = makeLabelSprite(`${{z}}`, 28);
    lbl.position.set(-0.8, 0, z);
    scene.add(lbl);
}}

// axis names (X, Y, Z) at ends
const labelX = makeLabelSprite('X', 48);
labelX.position.set(maxX, 0, 0); scene.add(labelX);
const labelY = makeLabelSprite('Y', 48);
labelY.position.set(0, maxY, 0); scene.add(labelY);
const labelZ = makeLabelSprite('Z', 48);
labelZ.position.set(0, 0, maxZ); scene.add(labelZ);

// ------------------------
// Blocks (placed with Z as height)
// ------------------------
const boxGeom = new THREE.BoxGeometry(1, 1, 1);
Object.entries(matrixData).forEach(([coord, key])=>{{
    if(!key) return;
    const [x,y,z] = JSON.parse(coord);
    const mat = new THREE.MeshPhongMaterial({{ color: colorMap[key] || 0xffffff, shininess:30 }});
    const cube = new THREE.Mesh(boxGeom, mat);
    // center cubes so their base sits on integer Z? 
    // If matrix uses integer z for cube center, keep center; if z meant as height index, adjust as needed.
    // Here we treat z as center height (like your previous code).
    cube.position.set(x, y, z);
    scene.add(cube);
}});

// ------------------------
// Lighting
// ------------------------
scene.add(new THREE.AmbientLight(0xffffff, 0.6));
const dir = new THREE.DirectionalLight(0xffffff, 0.9);
dir.position.set(10, -10, 20);
scene.add(dir);

// ------------------------
// Initial camera / controls target
// ------------------------
const centerX = (minX + maxX)/2;
const centerY = (minY + maxY)/2;
const centerZ = (minZ + maxZ)/2;
controls.target.set(centerX, centerY, centerZ);
const r0 = Math.max(maxX-minX, maxY-minY, 6);
camera.position.set(centerX + r0, centerY, centerZ + r0*0.5);
controls.update();

// ------------------------
// Rotate camera around Z only (keeps same height)
// ------------------------
function rotateAroundZ(angle){{
    const cx = controls.target.x, cy = controls.target.y;
    const dx = camera.position.x - cx;
    const dy = camera.position.y - cy;
    const r = Math.sqrt(dx*dx + dy*dy);
    const cur = Math.atan2(dy, dx);
    const next = cur + angle;
    camera.position.x = cx + r * Math.cos(next);
    camera.position.y = cy + r * Math.sin(next);
    camera.lookAt(controls.target);
    controls.update();
}}
window.rotateLeft = () => rotateAroundZ(0.15);
window.rotateRight = () => rotateAroundZ(-0.15);
window.resetView = () => {{
    camera.position.set(centerX + r0, centerY, centerZ + r0*0.5);
    controls.target.set(centerX, centerY, centerZ);
    controls.update();
}};

// ------------------------
// Billboarding for sprites (make them face camera) and render loop
// ------------------------
function animate(){{
    requestAnimationFrame(animate);
    controls.update();
    // make sprites face camera (billboard)
    scene.traverse(obj=>{{
        if(obj.type === 'Sprite') obj.lookAt(camera.position);
    }});
    renderer.render(scene, camera);
}}
animate();

// ------------------------
// Resize handler
// ------------------------
window.addEventListener('resize', ()=>{{
    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();
    renderer.setSize(window.innerWidth, window.innerHeight);
}});

</script>

<!-- Example buttons for rotation -->
<div style=""position:fixed; left:10px; bottom:10px; z-index:10;"">
  <button onclick=""rotateLeft()"">Rotate Left</button>
  <button onclick=""rotateRight()"">Rotate Right</button>
  <button onclick=""resetView()"">Reset</button>
</div>

</body>
</html>";

            File.WriteAllText(filePath.Replace(".html",$"_{DateTime.Now:yyyyMMddHHmmss}.html"), html);
        }
    }
}