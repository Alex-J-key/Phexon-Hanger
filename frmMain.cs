using System.Net;
using System.Reflection;
using System.Security.Policy;

namespace Phexon_Hanger
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            projects.Add(1, new Project("https://github.com/Alex-J-key/MazeGameOne/releases/download/V0.0.2/MazeGame.dll", "MazeGame", "A simple maze game made using C#. Use wasd or arrow keys to move."));
            projects.Add(2, new Project("https://github.com/Alex-J-key/Shapex/releases/download/v0.0.1/Shapex.dll", "Shapex", "A simple application which shows how shapes can be randomly generated. Press space to generate new world, use wasd to move"));

            foreach (KeyValuePair<int,Project> kvp in projects)
            { 
                Project p = kvp.Value;
                p.CheckIsInstalled();
            }
        }


        Dictionary<int, Project> projects = new Dictionary<int, Project>();
        public class Project
        {
            public string Url;
            public string Name;
            public string Description;
            public bool IsInstalled;
            public Project(string url, string name, string description)
            {
                Url = url;
                Name = name;
                Description = description;
            }
            public void Run()
            {
                string appPath = Path.Combine(AppContext.BaseDirectory, "Apps", $"{Name}.dll");

                var asm = Assembly.LoadFrom(appPath);

                var type = asm.GetType($"{Name}.frmMain");
                var form = (Form)Activator.CreateInstance(type)!;
                form.Show();
            }

            public bool CheckIsInstalled()
            {
                string appPath = Path.Combine(AppContext.BaseDirectory, "Apps", $"{Name}.dll");
                IsInstalled = File.Exists(appPath);   // was Directory.Exists
                return IsInstalled;
            }

            public async void Download()
            {
                string appsDir = Path.Combine(AppContext.BaseDirectory, "Apps");
                string outputPath = Path.Combine(appsDir, $"{Name}.dll");

                Directory.CreateDirectory(appsDir);   // no-op if it already exists

                if (CheckIsInstalled())
                {
                    MessageBox.Show("Already installed");
                    return;
                }

                using var client = new HttpClient();
                try
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(Url);
                    await File.WriteAllBytesAsync(outputPath, fileBytes);
                    MessageBox.Show($"{Name} has been installed");
                    CheckIsInstalled();
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    MessageBox.Show("No internet");
                }
            }
        }
        public void LoadDLL(int ProjectIndex)
        {
            Project p = projects[ProjectIndex];

            if (p.IsInstalled)
            {
                p.Run();
            }
            else
            {
                MessageBox.Show($"{p.Name} is not installed, now installing..");
                p.Download();
            }
        }
        private void btnMazeGame_Click(object sender, EventArgs e)
        {
            LoadDLL(1);
        }

        private void btnShapex_Click(object sender, EventArgs e)
        {
            LoadDLL(2);
        }
    }
}