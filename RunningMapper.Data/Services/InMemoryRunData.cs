using System;
using RunningMapper.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RunningMapper.Data.Services
{
    public class InMemoryRunData : IRunData
    {
        private List<Run> runs;
        private readonly int DISTRIBUTION_LENGTH = 10;
        private readonly int INCREMENT_PERIOD = 3;

        public InMemoryRunData()
        {
            var runsToAddCount = 10;

            runs = new List<Run>();

            for (var i = 0; i < runsToAddCount; i++)
            {
                var rand = new Random(i).Next();
                var scale = DISTRIBUTION_LENGTH * lengthFactor(rand);
                var run = new Run { Id = i };
                var routeGenerator = new RouteGenerator(seed: rand, length : DISTRIBUTION_LENGTH, scale: scale);

                foreach (var generatedPoint in routeGenerator)
                    run.AddPoint(generatedPoint);

                runs.Add(run);
            }

            int lengthFactor(int i) => (i / INCREMENT_PERIOD + 1);
        }

        public IEnumerable<Run> GetAll()
        {
            return runs.OrderBy(r => r.Id);
        }
    }
}
