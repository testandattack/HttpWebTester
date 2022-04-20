using System.Collections.Generic;

namespace ApiTestGenerator.Models.HttpArchiveAnalysis
{
    public class CaseSensitivityMismatches
    {
        public List<string> urls { get; set; }

        public CaseSensitivityMismatches()
        {
            urls = new List<string>();
        }
    }
}
