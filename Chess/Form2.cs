using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Chess
{
    public partial class Form2 : Form
    {
        private readonly string path;

        public Form2()
        {
            InitializeComponent();

            // Getting current working directy
            string loc = Application.StartupPath;
            int index = loc.IndexOf("bin");
            path = loc.Substring(0, index);

            // Accessing settings.yml and loading values
            using var reader = new StreamReader(path + "\\settings.yml");
            var yaml = new YamlStream();
            yaml.Load(reader);

            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            switch1.Checked = Boolean.Parse((string)mapping.Children["timed_game"]);
            switch2.Checked = Boolean.Parse((string)mapping.Children["timed_move"]);
            numericUpDown1.Value = Int32.Parse((string)mapping.Children["time_per_move"]);

            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Saving settings
            using var writer = new StreamWriter(path + "\\settings.yml");
            var data = new Dictionary<string, string>
            {
                { "time_per_move", numericUpDown1.Value.ToString() },
                { "timed_move", switch2.Checked ? "true" : "false" },
                { "timed_game", switch1.Checked ? "true" : "false" }
            };

            var serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            var yaml = serializer.Serialize(data);

            writer.Write(yaml);

            writer.Close();
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void switch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void switch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
