using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SM_Programming_Exercise.Library.Base;
using SM_Programming_Exercise.Library.Enums;
using System;
using System.Collections.Generic;

namespace SM_Programming_Exercise.Library.Data
{
    /// <summary>
    /// Implementation of InputBase which can process data in JSON format
    /// </summary>
    public class JsonData : InputBase
    {
        /// <summary>
        /// Override of the Read method, to handle JSON
        /// </summary>
        protected override void Read()
        {
            try
            {
                // Get JSON as string
                string jsonString = Console.ReadLine();

                // Deserialize the string to a dynamic JObject
                dynamic Json = JsonConvert.DeserializeObject(jsonString);

                // Read the data to the properties
                TableWidth = Json.TableWidth;
                TableHeight = Json.TableHeight;
                TileStartX = Json.TileStartX;
                TileStartY = Json.TileStartY;
                CommandList = TranslateCommands(Json.Commands);
            }
            catch (Exception e) // Generic exception handler, just an example
            {
                Console.WriteLine("Invalid data. Process aborted.");
                Console.WriteLine($"Exception details: \n\n {e.Message}");
                Console.ReadLine();
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Translates commands to Command objects, lazily yielded for best performance
        /// </summary>
        /// <param name="commands">The JArray of commands from a JSON object</param>
        /// <returns>Returns an enumerable of Commands</returns>
        private IEnumerable<Command> TranslateCommands(JArray commands)
        {
            foreach (int command in commands)
                yield return (Command)command;
        }
    }
}