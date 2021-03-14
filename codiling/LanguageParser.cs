using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codiling.Contexts;
using codiling.Models;

namespace codiling
{
    public class LanguageParser
    {
        public LanguageParser(codilingContext _context)
        {
            string languages = "C# = 1, VB.NET = 2, F# = 3, Java = 4, Python = 5, C(gcc) = 6, C++(gcc) = 7, Php = 8, Pascal = 9, Objective - C = 10, Haskell = 11, Ruby = 12, Perl = 13," +
               " Lua = 14, Nasm = 15, Sql Server = 16, Javascript = 17, Lisp = 18, Prolog = 19, Go = 20, Scala = 21, Scheme = 22, Node.js = 23, Python 3 = 24, Octave = 25, C(clang) = 26," +
               " C++(clang) = 27, C++(vc++) = 28, C(vc) = 29, D = 30, R = 31, Tcl = 32, MySQL = 33, PostgreSQL = 34, Oracle = 35, Swift = 37, Bash = 38, Ada = 39, Erlang = 40, Elixir = 41, " +
               " Ocaml = 42, Kotlin = 43, Brainf * ** = 44, Fortran = 45, Rust = 46, Clojure = 47";

            string[] languagesArray = languages.Split(",");

            List<Language> langs = new List<Language>();
            for (int i = 0; i < languagesArray.Length; i++)
            {
                Console.Write(i);
                Language language = new Language();
                language.Language1 = languagesArray[i].Split("=")[0].TrimStart().TrimEnd();
                language.Id = Convert.ToInt32(languagesArray[i].Split("=")[1].TrimStart().TrimEnd());
                langs.Add(language);

            }

            _context.Languages.AddRange(langs);
            _context.SaveChanges();

        }
    }
}
