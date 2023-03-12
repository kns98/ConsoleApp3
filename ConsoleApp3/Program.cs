// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

//Quick CSV Reader
//NB: Consider TDD (Test-driven-development) when creating such as 
//    app, which will ensure complaince to spec. 

/*
 *  While there are various specifications and implementations for the
   CSV format (for ex. [4], [5], [6] and [7]), there is no formal
   specification in existence, which allows for a wide variety of
   interpretations of CSV files.  This section documents the format that
   seems to be followed by most implementations:

   1.  Each record is located on a separate line, delimited by a line
       break (CRLF).  For example:

       aaa,bbb,ccc CRLF
       zzz,yyy,xxx CRLF

   2.  The last record in the file may or may not have an ending line
       break.  For example:

       aaa,bbb,ccc CRLF
       zzz,yyy,xxx

   3.  There maybe an optional header line appearing as the first line
       of the file with the same format as normal record lines.  This
       header will contain names corresponding to the fields in the file
       and should contain the same number of fields as the records in
       the rest of the file (the presence or absence of the header line
       should be indicated via the optional "header" parameter of this
       MIME type).  For example:

       field_name,field_name,field_name CRLF
       aaa,bbb,ccc CRLF
       zzz,yyy,xxx CRLF

Shafranovich                 Informational                      [Page 2]

RFC 4180       Common Format and MIME Type for CSV Files    October 2005


   4.  Within the header and each record, there may be one or more
       fields, separated by commas.  Each line should contain the same
       number of fields throughout the file.  Spaces are considered part
       of a field and should not be ignored.  The last field in the
       record must not be followed by a comma.  For example:

       aaa,bbb,ccc

   5.  Each field may or may not be enclosed in double quotes (however
       some programs, such as Microsoft Excel, do not use double quotes
       at all).  If fields are not enclosed with double quotes, then
       double quotes may not appear inside the fields.  For example:

       "aaa","bbb","ccc" CRLF
       zzz,yyy,xxx

   6.  Fields containing line breaks (CRLF), double quotes, and commas
       should be enclosed in double-quotes.  For example:

       "aaa","b CRLF
       bb","ccc" CRLF
       zzz,yyy,xxx

   7.  If double-quotes are used to enclose fields, then a double-quote
       appearing inside a field must be escaped by preceding it with
       another double quote.  For example:

       "aaa","b""bb","ccc"

*
*/

const string line_ending = "\r\n";
const string delimiter = ",";

string my_text_test_case_1 = "aaa,bbb,ccc" + line_ending + "ddd,eee,fff";
string my_text_test_case_2 = "aaa,bbb,ccc" + line_ending + "ddd,eee,fff" + line_ending;

Console.WriteLine("Scenario 1");
string[] row_1 = my_text_test_case_1.Split(line_ending);
CreateCSV(delimiter, row_1);

Console.WriteLine("Scenario 2");
string[] row_2 = my_text_test_case_2.Split(line_ending);
CreateCSV(delimiter, row_2);

Console.ReadLine();

void CreateCSV(string delimiter, string[] rows)
{
    foreach (var row in rows)
    {

        string[] fields = row.Split(delimiter);
        if (fields.Length == 1 && fields[0] == "") 
            continue;

        for (int i = 0; i < fields.Length; i++)
        {
            string? field = fields[i];
            Console.WriteLine("Field " + i + " : " + field);
        }
    }
}

//
// HW: Implement point 3. i.e. Header Fields. 
//

