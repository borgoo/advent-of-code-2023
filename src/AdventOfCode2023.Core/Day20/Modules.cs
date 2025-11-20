namespace AdventOfCode2023.Core.Day20;

internal static partial class Day20
{

    internal abstract partial class PartShared
    {
        public record Event(string From, string To, SignalEnum Signal);

        public abstract class Module
        {
            public abstract void UpdateStatus(string from, SignalEnum signal);
            public abstract SignalEnum GetOutputSignal();
        }

        public class BroadcastModule : Module
        {

            public const string Id = "broadcaster";

            private static readonly SignalEnum _outputSignal = SignalEnum.Low;

            public override SignalEnum GetOutputSignal() => _outputSignal;

            public override void UpdateStatus(string from, SignalEnum signal)
            {
                throw new NotImplementedException();
            }
        }

        public class FlipFlopModule : Module
        {
            private bool _on = false;

            public bool IsOn => _on;


            public override void UpdateStatus(string from, SignalEnum signal)
            {
                if (signal == SignalEnum.High) return;

                _on = !_on;
            }

            public override SignalEnum GetOutputSignal() => _on ? SignalEnum.High : SignalEnum.Low;

        }

        public class ConjunctionModule : Module
        {
            private Dictionary<string, SignalEnum> _inputSignals = [];

            public override void UpdateStatus(string from, SignalEnum signal)
            {
                _inputSignals[from] = signal;
            }

            public override SignalEnum GetOutputSignal() => _inputSignals.All(input => input.Value == SignalEnum.High) ? SignalEnum.Low : SignalEnum.High;

            public void InitStatus(string from)
            {
                _inputSignals[from] = SignalEnum.Low;
            }
        }

        public class DeadEndModule : Module
        {
            public (string from, SignalEnum signal) LastReceivedSignal { get; private set; }
            public override SignalEnum GetOutputSignal()
            {
                throw new NotImplementedException();
            }

            public override void UpdateStatus(string from, SignalEnum signal)
            {
                LastReceivedSignal = (from, signal);
            }
        }

    }
}