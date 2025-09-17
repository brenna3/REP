using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor 1: no parameters
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: one parameter
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: two parameters
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for top
    public int GetTop()
    {
        return _top;
    }

    // Setter for top
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for bottom
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Method to get fraction string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to get decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}