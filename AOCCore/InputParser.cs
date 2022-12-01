using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class InputParser
{
    public void Test()
    {
        var folder = @"C:\Users\Rogier\Dropbox\AOC2\AOC2\InputFiles\";
        ;
        foreach (var dir in new DirectoryInfo(folder).GetDirectories().Skip(10))
        {
            Console.WriteLine(dir.Name);
            var fileanem = dir.FullName + @"\input.txt";
            var lines = File.ReadAllLines(fileanem).ToList();
            lines.Take(5).ToList().Print("\n");
            TryParse(lines);
            Console.ReadLine();
        }


    }

    List<int> Numbers = new List<int>();
    List<string> Rows = new List<string>(); 
    List<List<int>> NumberedRows = new List<List<int>>();
    List<List<string>> SplitRows = new List<List<string>>();
    List<List<string>> Blocks = new List<List<string>>();
    List<List<List<int>>> NumberedBlocks = new List<List<List<int>>>();
    string FirstRow = "";


    public void TryParse(List<string> lines)
    {
        Numbers = new List<int>();
        Rows = lines;
        Blocks = new List<List<string>>();
        NumberedBlocks = new List<List<List<int>>>();
        NumberedRows = lines.Select(line => GetNumbers(line)).ToList();
        SplitRows = lines.Select(line => line.Split(" ").ToList()).ToList();
        Console.WriteLine();
        string Caps(bool p) { return p ? "TRUE =D" : "FALSE >:("; }

        //Console.WriteLine("Single line:\t{0}", Caps(lines.Count == 1));
        //single collumn
        ////normal
        ///
        ////blocks
        List<string> subset = new List<string>();
        foreach (var line in lines)
        {
            if (line == "")
            {
                Blocks.Add(subset);
                subset = new List<string>();
            }
            subset.Add(line);
        }
        Blocks.Add(subset);
        subset = new List<string>();


        try
        {
            NumberedBlocks = Blocks.Select(x => x.Select(x => GetNumbers(x)).ToList()).ToList();
            Numbers = NumberedBlocks.Select(x => x.Flat()).ToList().Flat();
        }
        catch { }

        //grid

        Console.WriteLine("Rows________:\t{0}", Rows.Count);
        Console.WriteLine("Numbers_____:\t{0}", Numbers.Count );
        Console.WriteLine("NumberedRows:\t{0} {1}", NumberedRows.Count, NumberedRows.Average(x => x.Count));
        Console.WriteLine("SplitRow____:\t{0} {1}", SplitRows.Count, SplitRows.Average(x => x.Count));
        Console.WriteLine("Blocks______:\t{0}", Blocks.Count);
        //Console.WriteLine("NBlocks_____:\t{0} {1}", NumberedBlocks.Count, Caps(NumberedBlocks.Count > 1));
        Numbers.Take(10).ToList().Print(" ");
    }

    public List<int> GetNumbers(string line)
    {
        return Regex.Split(line, @"/^[-+]?[1-9]\d*$/").Where(x => !string.IsNullOrEmpty(x)).Where(x => x.Length <9).Select(int.Parse).ToList() ;
    }
}

