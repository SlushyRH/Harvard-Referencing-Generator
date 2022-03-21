using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarvardRef
{
    internal class Program
    {
        private static bool exitProgram = false;

        [STAThread]
        static void Main(string[] args)
        {
            while (!exitProgram)
            {
                Console.WriteLine(@"  _  _                          _   ___      __                            ___                       _           ");
                Console.WriteLine(@" | || |__ _ _ ___ ____ _ _ _ __| | | _ \___ / _|___ _ _ ___ _ _  __ ___   / __|___ _ _  ___ _ _ __ _| |_ ___ _ _ ");
                Console.WriteLine(@" | __ / _` | '_\ V / _` | '_/ _` | |   / -_)  _/ -_) '_/ -_) ' \/ _/ -_) | (_ / -_) ' \/ -_) '_/ _` |  _/ _ \ '_|");
                Console.WriteLine(@" |_||_\__,_|_|  \_/\__,_|_| \__,_| |_|_\___|_| \___|_| \___|_||_\__\___|  \___\___|_||_\___|_| \__,_|\__\___/_|  ");
                Console.WriteLine(@"                                                                                                                 ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Leave text empty if any of the following text's don't apply to you!");
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the author's last name: ");
                string authorLastName = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the author's first name: ");
                string authorFirstName = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the year of publication: ");
                string yearOfPub = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the title of the website: ");
                string webTitle = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the publisher of the website: ");
                string webPublisher = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the day you viewed this website: ");
                string day = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the month you viewed this website: ");
                string month = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the year you viewed this website: ");
                string year = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Please enter the url of the website: ");
                string url = Console.ReadLine();
                Console.WriteLine("");

                string cit = OrganizeReferenceCitation(authorLastName, authorFirstName, yearOfPub, webTitle, webPublisher, day, month, year, url);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Citation");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(cit);
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Do you want to copy the citation? (y/n): ");
                char ans = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                Console.WriteLine("");

                if (ans == 'y' || ans == 'Y')
                    CopyToClipboard(cit);

                QuitConfirm();
            }

            Environment.Exit(0);
        }

        private static string OrganizeReferenceCitation(string authorLastName, string authorFirstName, string yearOfPublication, string websiteTitle, string websitePublisher, string viewedDay, string viewedMonth, string viewedYear, string url)
        {
            StringBuilder citation = new StringBuilder();

            if (!string.IsNullOrEmpty(authorLastName)) citation.Append($"{authorLastName}, ");
            if (!string.IsNullOrEmpty(authorFirstName)) citation.Append($"{authorFirstName.ToCharArray()[0].ToString().ToUpper()} ");
            if (!string.IsNullOrEmpty(yearOfPublication)) citation.Append($"{yearOfPublication}, ");
            if (!string.IsNullOrEmpty(websiteTitle)) citation.Append($"{websiteTitle}, ");
            if (!string.IsNullOrEmpty(websitePublisher)) citation.Append($"{websitePublisher}, ");
            if (!string.IsNullOrEmpty(viewedDay) && !string.IsNullOrEmpty(viewedMonth) && !string.IsNullOrEmpty(viewedYear)) citation.Append($"viewed {viewedDay} {viewedMonth} {viewedYear}, ");
            if (!string.IsNullOrEmpty(url)) citation.Append($"<{url}>");

            return citation.ToString();
        }

        private static void CopyToClipboard(string msg)
        {
            Clipboard.SetText(msg);
        }

        private static void QuitConfirm()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press 'Q' to exit app or press any other key to reference another text.");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.KeyChar == 'Q' || key.KeyChar == 'q')
            {
                exitProgram = true;
            }
            else
                Console.Clear();
        }
    }
}
