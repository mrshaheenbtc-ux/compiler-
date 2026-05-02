namespace Compiler_Phase_2;
public class Parser
{
    private List<Token> tokens;
    private int index = 0;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    private Token CurrentToken()
    {
        if (index < tokens.Count)
            return tokens[index];
        return null!;
    }

    private void Match(string expectedType)
    {
        if (CurrentToken() != null && CurrentToken().Type == expectedType)
        {
            index++;
        }
        else
        {
            throw new Exception("Syntax Error: Expected " + expectedType);
        }
    }

    public void Parse()
    {
        while (CurrentToken() != null)
        {
            Statement();
        }
    }

    private void Statement()
    {
        if (CurrentToken().Type == "Keyword" && CurrentToken().Lexeme == "int")
        {
            Declaration();
        }
        else if (CurrentToken().Type == "Identifier")
        {
            Assignment();
        }
        else
        {
            throw new Exception("Syntax Error: Invalid Statement");
        }
    }

    private void Declaration()
    {
        Match("Keyword");
        Match("Identifier");
        Match("Semicolon");
    }

    private void Assignment()
    {
        Match("Identifier");
        Match("Assignment_Op");
        Expression();
        Match("Semicolon");
    }

    private void Expression()
    {
        if (CurrentToken().Type == "Number")
        {
            Match("Number");
        }
        else if (CurrentToken().Type == "Identifier")
        {
            Match("Identifier");
        }
        else
        {
            throw new Exception("Syntax Error: Invalid Expression");
        }
    }
}

