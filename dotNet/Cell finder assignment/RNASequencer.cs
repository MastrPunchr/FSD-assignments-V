namespace RNACellFinder;

public class RNASequencer
{
    public static void Sequencer()
    {
        string sequence = "";
        bool quit = false;
        while(!quit){
            Console.WriteLine("Enter RNA sequence (leave empty to exit):");
            string userInput = Console.ReadLine();
            if (userInput.Trim() == "") return;
            userInput = userInput.ToUpper().Trim();
            if (userInput.Except("ACGU").Any())
            {
                Console.WriteLine("\nInvalid character\n");
                continue;
            }

            if (userInput.Length % 3 != 0)
            {
                Console.WriteLine("\nInvalid length\n");
                continue;
            }
            sequence = userInput;
            quit = !quit;
        }

        List<string> codons = new List<string>();
        Dictionary<string, int> proteins = new Dictionary<string, int>()
        {
            {"Methionine", 0},
            {"Phenylalanine", 0},
            {"Leucine", 0},
            {"Serine", 0},
            {"Tyrosine", 0},
            {"Cysteine", 0},
            {"Tryptophan", 0}
        };
        
        //Separate into individual codons
        for (int i = 0; i < sequence.Length; i += 3)
        {
            string codon = $"{sequence[i]}{sequence[i+1]}{sequence[i+2]}";
            codons.Add(codon);
        }

        foreach (string codon in codons)
        {
            switch(codon)
            {
                case "AUG":
                    //Methionine
                    proteins["Methionine"]++;
                    continue;
                case "UUU":
                case "UUC":  
                    //Phenylalanine
                    proteins["Phenylalanine"]++;
                    continue;
                case "UUA":
                case "UUG":
                    //Leucine
                    proteins["Leucine"]++;
                    continue;
                case "UCU":
                case "UCC":
                case "UCA":
                case "UCG":
                    //Serine
                    proteins["Serine"]++;
                    continue;
                case "UAU":
                case "UAC":
                    //Tyrosine
                    proteins["Tyrosine"]++;
                    continue;
                case "UGU":
                case "UGC":
                    //Cysteine
                    proteins["Cysteine"]++;
                    continue;
                case "UGG":
                    //Tryptophan
                    proteins["Tryptophan"]++;
                    continue;
                case "UAA":
                case "UAG":
                case "UGA":
                    //STOP
                    break;
            }
        }
        if (proteins.Values.Max() == 0)
        {
            Console.WriteLine("\nIf you're somehow reading this you either started the string with a STOP codon or did something I have yet to think of, impressive.");
            return;
        }
        
        Console.WriteLine($"Protein Occurrences:\nTryptophan: {proteins["Tryptophan"]}\nSerine: {proteins["Serine"]}\nTyrosine: {proteins["Tyrosine"]}\nMethionine: {proteins["Methionine"]}\nPhenylalanine: {proteins["Phenylalanine"]}");
        
        //string proteinName = (from keyValuePair in proteins where keyValuePair.Value == proteins.Values.Max() select keyValuePair.Key).FirstOrDefault();
        //^LINQ version that is far more optimized
        string proteinName = null;
        foreach (var keyValuePair in proteins)
        {
            if (keyValuePair.Value != proteins.Values.Max()) continue;
            proteinName = keyValuePair.Key;
            break;
        }
        Console.WriteLine($"Protein '{proteinName}' has the most occurrences with {proteins.Values.Max()} repetitions in the RNA sequence");
    }
}