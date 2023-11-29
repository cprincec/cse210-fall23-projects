using System;
public class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public string GetWord()
    {
        if (_isHidden)
        {
            // Calculate the length of the word designated as hidden
            // and create a string of underscores with the same length
            return new string('_', _word.Length);
        }
        else
        {
            return _word;
        }
    }
}
