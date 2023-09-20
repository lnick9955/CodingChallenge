using System;

namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        public string GetBirthMonth(Person person, string descendantName)
        {
            // Check if the current person's name matches the target descendant's name
            // This check must be at the top of the function because this is
            // an exit condition for recursive function calls.
            if (person.Name == descendantName)
            {
                return person.Birthday.ToString("MMMM");
            }

            // Recursively search through the descendants
            foreach (var decendent in person.Descendants)
            {
                // Recursively call the function on each descendant to search for the target name
                var birthMonth = GetBirthMonth(decendent, descendantName);

                // If a non-empty birth month is found in the descendants, propagate it up the tree
                if (birthMonth != "")
                {
                    return birthMonth;
                }
            }

            return "";
        }
    }
}