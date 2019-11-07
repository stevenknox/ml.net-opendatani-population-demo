//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace SampleRegression.Model.DataModels
{
    public class ModelInput
    {
        [ColumnName("Geo_Name"), LoadColumn(0)]
        public string Geo_Name { get; set; }


        [ColumnName("Geo_Code"), LoadColumn(1)]
        public string Geo_Code { get; set; }


        [ColumnName("Mid_Year_Ending"), LoadColumn(2)]
        public float Mid_Year_Ending { get; set; }


        [ColumnName("Gender"), LoadColumn(3)]
        public string Gender { get; set; }


        [ColumnName("Age"), LoadColumn(4)]
        public float Age { get; set; }


        [ColumnName("Population_Estimate"), LoadColumn(5)]
        public float Population_Estimate { get; set; }


    }
}
