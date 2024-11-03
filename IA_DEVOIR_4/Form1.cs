using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

////
///     Nom: ISAAC Sammuel Ramclief
///     Cours: Introduction à l'intelligence artificielle
///     Devoir: Devoir 4
///             -> Jeu de Dames
///             
///     ****    VOIR LA METHODE UpdateButtonTexts   ****
///

namespace IA_DEVOIR_4
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        public static string imagePath = Path.Combine(Application.StartupPath, "..","..","crown_icon.png");
        public static List<List<int>> solutions = new List<List<int>>();

        /// <summary>
        /// Methods that runs on Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // List of 16 positions
            List<int> positions = new List<int>(Enumerable.Range(1, 16));

            // List of 4 persons (we can label them A, B, C, D)
            List<string> persons = new List<string> { "A", "B", "C", "D" };

            // Store all possible placements
            List<List<KeyValuePair<int, string>>> placements = new List<List<KeyValuePair<int, string>>>();

            //Store positions of placements

            // Generate all permutations of persons and place them in different positions
            GenerateGroups.GeneratePlacements(persons, new List<KeyValuePair<int, string>>(), positions, placements);
            
            //Each placement
            
            foreach (var placement in placements)
            {
                if (GenerateGroups.IsSolution(placement))
                {
                    List<int> solution = new List<int>();
                    foreach(var pair in placement)
                    {
                        solution.Add(pair.Key);
                    }


                    // Sort the solution list to handle duplicate sets in different orders
                    solution.Sort();
                    solutions.Sort();

                    // Check if this solution is already in the list
                    bool isDuplicate = false;
                    foreach (var existingSolution in solutions)
                    {
                        existingSolution.Sort();
                        if (AreListsEqual(solution, existingSolution))
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    // Only add if it's not a duplicate
                    if (!isDuplicate)
                    {
                        solutions.Add(solution);
                    }


                }
            }
            UpdateButtonTexts();
        }


        /// <summary>
        /// Updates the buttons with the crown image based on if a button is at a position within a solution
        /// </summary>
        private void UpdateButtonTexts()
        {
            for (int i = 1; i <= 16; i++)
            {
                // I manually added buttons from button1 to button16

                // Find the button by name
                Button button = this.Controls.Find($"button{i}", true)[0] as Button;

                //Check if the number is in the solutions list
                if (solutions[0].Contains(i))
                {
                    
                    int padding = 10;
                    Size imageSize = new Size(button.Width - padding * 2,button.Height - padding * 2);
                    
                    Image img = Image.FromFile(imagePath);
                    button.Image = new Bitmap(img, imageSize);

                    button.ImageAlign = ContentAlignment.MiddleCenter;

                }
                

            }
        }

        /// <summary>
        /// Helper method to compare two lists of integers
        /// </summary>
        /// <param name="list1">The first list
        /// <param name="list2">The second list
        /// <returns></returns>
        static bool AreListsEqual(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                    return false;
            }
            return true;
        }

    }
}
