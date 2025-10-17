using System;
using System.Collections.Generic;
using System.Text;

public class OldPhonePadTest
{
    public static string ConvertOldPhoneText(string input)
    {
        // write the number and letter code here below
        var keypad = new Dictionary<char, string>
        {
            {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"},
            {'5', "JKL"}, {'6', "MNO"},
            {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
            {'0', " "}
        };

        StringBuilder message = new StringBuilder();
        char lastButton = '\0';
        int pressTimes = 0;

        // using Loop for each button pressed
        for (int i = 0; i < input.Length; i++)
{
            char key = input[i];

            if (key == '#'){
               break; // end of message
            } 

            if (key == '*') // backspace
            {
                if (message.Length > 0)
                    message.Remove(message.Length - 1, 1);

                lastButton = '\0';
                pressTimes = 0;
                continue;
            }

            if (key == ' ') // pause or next letter
            {
                AddCharacter();
                lastButton = '\0';
                pressTimes = 0;
                continue;
            }

            if (!keypad.ContainsKey(key)) {
             continue;
            }
            
            if (key == lastButton){
              pressTimes++; // same key pressed again
            } else{
           
                AddCharacter();
                lastButton = key;
                pressTimes = 1;
            }
        }

        // Add the last character if needed
        AddCharacter();

        return message.ToString();

        // Helper function to add a letter based on key and press count
        void AddCharacter()
        {
            if (lastButton == '\0') return;
            string letters = keypad[lastButton];
            int index = (pressTimes - 1) % letters.Length;
            message.Append(letters[index]);
        }
 }

    // Testing the function
    public static void Main()
    {
        Console.WriteLine(ConvertOldPhoneText("33#"));                 // E
        Console.WriteLine(ConvertOldPhoneText("227#"));                // BP
        Console.WriteLine(ConvertOldPhoneText("4433555 555666#"));     // HELLO
        Console.WriteLine(ConvertOldPhoneText("8 88777444666*664#"));  // Test case
    }
}