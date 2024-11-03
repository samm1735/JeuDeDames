using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_DEVOIR_4
{
    internal class GenerateGroups
    {
        // Recursive method to generate all ways to place 4 persons in 16 positions
        public static void GeneratePlacements(List<string> persons, List<KeyValuePair<int, string>> currentPlacement, List<int> availablePositions, List<List<KeyValuePair<int, string>>> allPlacements)
        {
            // Base case: if all persons are placed, store the result
            if (currentPlacement.Count == persons.Count)
            {
                allPlacements.Add(new List<KeyValuePair<int, string>>(currentPlacement));
                return;
            }

            // Place the next person in each available position
            for (int i = 0; i < availablePositions.Count; i++)
            {
                int position = availablePositions[i];
                string person = persons[currentPlacement.Count];

                // Add current placement
                currentPlacement.Add(new KeyValuePair<int, string>(position, person));

                // Recursively place the next person
                List<int> newAvailablePositions = new List<int>(availablePositions);
                newAvailablePositions.RemoveAt(i);
                GeneratePlacements(persons, currentPlacement, newAvailablePositions, allPlacements);

                // Backtrack
                currentPlacement.RemoveAt(currentPlacement.Count - 1);
            }
        }

        /// <summary>
        /// Checks if a placement is a valid solution
        /// </summary>
        /// <param name="placement"></param>
        /// <returns></returns>
        internal static bool IsSolution(List<KeyValuePair<int, string>> placement)
        {
            int[] positions = { placement[0].Key, placement[1].Key, placement[2].Key, placement[3].Key };

            // Check if the positions are in different rows
            int[] matchedItems = Array.FindAll(positions, x => x == 1 || x == 2 || x == 3 || x == 4);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 5 || x == 6 || x == 7 || x == 8);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 9 || x == 10 || x == 11 || x == 12);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 13 || x == 14 || x == 15 || x == 16);
            if (matchedItems.Length > 1) return false;

            // Check if the positions are in different columns
            matchedItems = Array.FindAll(positions, x => x == 1 || x == 5 || x == 9 || x == 13);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 2 || x == 6 || x == 10 || x == 14);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 3 || x == 7 || x == 11 || x == 15);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 4 || x == 8 || x == 12 || x == 16);
            if (matchedItems.Length > 1) return false;

            // Check if the positions are in different diagonals
            // Main diagonals
            matchedItems = Array.FindAll(positions, x => x == 1 || x == 6 || x == 11 || x == 16);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 4 || x == 7 || x == 10 || x == 13);
            if (matchedItems.Length > 1) return false;

            // Shorter diagonals of length 3
            matchedItems = Array.FindAll(positions, x => x == 2 || x == 7 || x == 12);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 5 || x == 10 || x == 15);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 3 || x == 6 || x == 9);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 8 || x == 11 || x == 14);
            if (matchedItems.Length > 1) return false;

            // Shorter diagonals of length 2
            matchedItems = Array.FindAll(positions, x => x == 1 || x == 7);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 2 || x == 8);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 5 || x == 11);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 6 || x == 12);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 3 || x == 11);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 4 || x == 10);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 7 || x == 13);
            if (matchedItems.Length > 1) return false;

            matchedItems = Array.FindAll(positions, x => x == 8 || x == 14);
            if (matchedItems.Length > 1) return false;

            return true;
        }


    }
}
