using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.day25
{
    public class Solver
    {
        int? _solution;
        int _currentInput = 0;
        SignalGenerator _signalGenerator;
        List<Signal> _signals = new List<Signal>();

        public Solver(IEnumerable<string> input)
        {
            _solution = null;
            _signalGenerator = new SignalGenerator(input);
            _signalGenerator.SignalOutput += _signalGenerator_SignalOutput;
        }

        public int Solve(int initialValue)
        {
            _signalGenerator.Start(_currentInput);

            // wait for solution to be found
            while (!_solution.HasValue) { }

            return _solution.Value;
        }

        private void _signalGenerator_SignalOutput(object sender, SignalOutputEventArgs e)
        {
            if (_signals.Any(s => s.RegisterValue('a') == e.Signal.RegisterValue('a')))
            {
                _signalGenerator.Stop();

                var success = true;
                for (int i = 0; i < _signals.Count; i++)
                {
                    if (i % 2 != _signals[i].RegisterValue('b'))
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    _solution = _currentInput;
                    return;
                }

                _signals.Clear();
                _currentInput++;
                _signalGenerator.Start(_currentInput);
            }

            _signals.Add(e.Signal);
        }
    }
}
