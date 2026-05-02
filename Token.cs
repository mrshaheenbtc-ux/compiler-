namespace Compiler_Phase_2
{
    public class Token
    {
        public string Lexeme { get; set;}
        public string Type { get; set;}

        public Token( string lexeme , string type)
        {
            Lexeme = lexeme;
            Type = type;
        }
    }
}
