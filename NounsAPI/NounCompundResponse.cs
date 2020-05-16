using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NounsAPI
{
    public class NounCompoundResponse
    {
        /// <summary>
        /// List<List<Compound>>:
        /// ["pack pack ", [[0, 4], [5, 4]]],
        /// ["apples food apples food ", [[428, 6], [435, 4], [440, 6], [447, 4]]],
        /// ----------------------------
        /// List<Compound>:
        /// ["pack pack ", [[0, 4], [5, 4]]]
        /// ---------------------------------------
        /// Compound = String, List<List<int>>:
        /// "pack pack ", [[0, 4], [5, 4]]
        /// ---------------------------------------
        /// String: "pack pack "
        /// List<List<int>>: [[0, 4], [5, 4]
        /// List<int>: [0, 4]
        /// </summary>
        [JsonProperty("result")]
        public List<List<int>> Result { get; set; }
        public float ServerExecutionTime { get; set; }
    }
}
