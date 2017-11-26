using System;

public interface IThruster
{
    void Up();
    void Down();
    void Forward(bool afterBurner);
    void Back();
}

