﻿namespace TestModels
{
    public class TestModel5
    {
        public int TM5Property1 { get; set; }

        public List<TestModel1>? TM5Property2 { get; set; }

        public string TM5Property3 { get; set; } = string.Empty;

        public TestModel2 TM5Property4 { get; set; } = new();

        public List<TestModel3> TM5Property5 { get; set; } = [];

        public TestModel4 TM5Property6 { get; set; } = new();
    }
}
