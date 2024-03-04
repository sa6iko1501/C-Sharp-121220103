using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application2
{
    /*
     * BG: Файлът coordinates.json е генериран успешно и е с коректни стойности обаче при google-maps.html възниква грешка, тъй като 
     * сега има ново API и очаква callback с аргументи. Може да видите конзолата в browser-а за повече детайли.
     */
    internal class MapCoordinatesParser
    {
        private String pathToInput = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..", "..","..","resources", "input-01.txt");
        public Dictionary<float, float> coordinates = new Dictionary<float, float>();
        public MapCoordinatesParser() {
            parseInput();
        }
        /*
         * Will go through the .txt file specified by pathToInput and will put all lines of the file in a List<String>
         */
        private void parseInput()
        {
            // Read the txt. file
            List<String> input = new List<String>();
            if (File.Exists(pathToInput))
            {
                using (StreamReader reader = new StreamReader(pathToInput))
                {
                    String line;
                    int limiter = 0;
                    /*
                     * Since there is for cycle logic in the function below we will limit the input only to the first 100 lines of input.
                     * Could be resolved with multithreading and pagination at a later time if the need arises
                     */
                    while ((line = reader.ReadLine()) != null && limiter++ < 100) {
                    input.Add(line);
                    }
                }
                formatInput(input);
            }
        }
        /*
         * Get the already read lines from the input file and split them into lat and len pairs. After that split each pair and add
         * it to a Dictionary to prepare for conversion to float
         */
        private void formatInput(List<String> lines)
        {
            Dictionary<String, String> latAndLenInStringForm = new Dictionary<String, String>();
            List<String> pairs = new List<String>();    
            foreach (String line in lines) { 
                string[] latAndLng = line.Split(';');
                foreach (String latLng in latAndLng)
                {
                    pairs.Add(latLng);
                }
            }
            foreach (String pair in pairs) 
            {
                String[] parts = pair.Split(",");
                latAndLenInStringForm.Add(parts[0], parts[1]);
            }
            convertToFloatAndAddToClassProperty(latAndLenInStringForm);
        }

        /*
         * Get a dictionary with lat and len in String form, convert them to float and pass them to the coordinates Dictionary in the class
         */
        private void convertToFloatAndAddToClassProperty(Dictionary<String, String> latAndLenInStringForm)
        {
            foreach (KeyValuePair<String, String> pair in latAndLenInStringForm)
            {
                String lat = pair.Key;
                String len = pair.Value;
                float latReadyForInsertion;
                float lenReadyForInsertion;
                if(float.TryParse(lat, out latReadyForInsertion) && float.TryParse(len, out lenReadyForInsertion))
                {
                    coordinates.Add(latReadyForInsertion, lenReadyForInsertion);
                }
            }
            createAndFillJSONResourceFile();
        }

        private bool createAndFillJSONResourceFile()
        {
            bool isSuccess = false;
            List<Object> coordinatesList = new List<Object>();
            String jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "coordinates.json");
            // Convert the data from the dictionary to Object since it will be simpler to put in JSON
            foreach (var coordinate in coordinates)
            {
                var coordinateObject = new { lat = coordinate.Key, lng = coordinate.Value };
                coordinatesList.Add(coordinateObject);
            }
            string jsonOutput = JsonSerializer.Serialize(coordinatesList, new JsonSerializerOptions { WriteIndented = true});
            // Delete old coordinates.json if already one is generated
            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }
            File.WriteAllText(jsonPath, jsonOutput);
            if (File.Exists(jsonPath)){
                isSuccess = true;
            }
            return isSuccess;
        }
        
    }
}
