﻿namespace Test_Task_Forms.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string CityFrom { get; set; }
        public string AddressFrom { get; set; }
        public string CityTo { get; set; }
        public string AddressTo { get; set; }
        public string Weight { get; set; }
        public string DateOfGet { get; set; }
        public string? TrackNumber { get; set; }
    }
}
