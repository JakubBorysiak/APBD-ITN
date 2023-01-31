using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace C2
{
    public class Student
    {
        [JsonPropertyName("name")]
        [XmlElement(elementName: "name")]
        public string name { get; set; }

        [JsonPropertyName("surname")]
        [XmlElement(elementName: "surname")]
        public string surname { get; set; }

        [JsonPropertyName("dob")]
        [XmlElement(elementName: "dob")]
        public DateTime dob { get; set; }

        [JsonPropertyName("studId")]
        [XmlElement(elementName: "studId")]
        public string studId { get; set; }

        private string _email;

        [JsonPropertyName("mothersName")]
        [XmlElement(elementName: "mothersName")]
        public string mothersName { get; set; }

        [JsonPropertyName("fathersName")]
        [XmlElement(elementName: "fathersName")]
        public string fathersName { get; set; }

        [JsonPropertyName("email")]
        [XmlElement(elementName: "email")]
        public string email
        {
            get => this._email;
            set => this._email = value ?? throw new ArgumentNullException();
        }

        [XmlElement(ElementName = "studies")]
        public Studies Studies
        {
            get => studies;
            set => studies = value ?? throw new ArgumentNullException();
        }
    }
}