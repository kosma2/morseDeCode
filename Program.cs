using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO.Ports;

namespace morse
{
    public class Program
    {
        static SerialPort _serialPort;

        public static void Main()
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>();

            morseCode.Add('a', ".-");
            morseCode.Add('b', "-...");
            morseCode.Add('c', "-.-.");
            morseCode.Add('d', "-..");
            morseCode.Add('e', ".");
            morseCode.Add('f', "..-.");
            morseCode.Add('g', "--.");
            morseCode.Add('h', "....");
            morseCode.Add('i', "..");
            morseCode.Add('j', ".---");
            morseCode.Add('k', "-.-");
            morseCode.Add('l', ".-..");
            morseCode.Add('m', "--");
            morseCode.Add('n', "-.");
            morseCode.Add('o', "---");
            morseCode.Add('p', ".--.");
            morseCode.Add('q', "--.-");
            morseCode.Add('r', ".-.");
            morseCode.Add('s', "...");
            morseCode.Add('t', "-");
            morseCode.Add('u', "..-");
            morseCode.Add('v', "...-");
            morseCode.Add('w', ".--");
            morseCode.Add('x', "-..-");
            morseCode.Add('y', "-.--");
            morseCode.Add('z', "--..");

            Dictionary<string, char> codeMorse = new Dictionary<string, char>();

            codeMorse.Add(".-", 'a');
            codeMorse.Add("-...", 'b');
            codeMorse.Add("-.-.", 'c');
            codeMorse.Add("-..", 'd');
            codeMorse.Add(".", 'e');
            codeMorse.Add("..-.", 'f');
            codeMorse.Add("--.", 'g');
            codeMorse.Add("....", 'h');
            codeMorse.Add("..", 'i');
            codeMorse.Add(".---", 'j');
            codeMorse.Add("-.-", 'k');
            codeMorse.Add(".-..", 'l');
            codeMorse.Add("--", 'm');
            codeMorse.Add("-.", 'n');
            codeMorse.Add("---", 'o');
            codeMorse.Add(".--.", 'p');
            codeMorse.Add("--.-", 'q');
            codeMorse.Add(".-.", 'r');
            codeMorse.Add("...", 's');
            codeMorse.Add("-", 't');
            codeMorse.Add("..-", 'u');
            codeMorse.Add("...-", 'v');
            codeMorse.Add(".--", 'w');
            codeMorse.Add("-..-", 'x');
            codeMorse.Add("-.--", 'y');
            codeMorse.Add("--..", 'z');

            /// port stuff
            _serialPort = new SerialPort();
            _serialPort.BaudRate = 9600;
            _serialPort.PortName = "COM3";
            _serialPort.Open();
            // port stuff
            string codBld = "";
            string tranBld = "";
            bool letterStart = false;
            System.Console.WriteLine("ready");
            while (true)
            {
                int input = _serialPort.ReadChar();
                Thread.Sleep(200);

                if (input == '2')
                {
                    letterStart = true;
                }
                if (letterStart)
                {
                    if (input == '.' || input == '-')
                    {
                        codBld = String.Concat(codBld, (char)input);
                        System.Console.WriteLine("codBld is " + codBld);
                    }
                    if (input == '2')
                    {
                        foreach (KeyValuePair<string, char> kvp in codeMorse)
                        {

                            if (codBld == kvp.Key)
                            {
                                codBld = "";
                                tranBld = String.Concat(tranBld, kvp.Value);
                                System.Console.WriteLine("tranBld is " + tranBld);
                            }
                        }
                    }
                    if (input == '3')
                    {
                        tranBld = String.Concat(tranBld, " ");
                        codBld = "";
                    }
                }
                
            }
        }
    }
}