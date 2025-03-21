using System;
using System.Collections.Generic;
namespace RDE.Input;

public static class Input {
    public static List<(Func<bool>, Button)> Buttons = new();
    
    public static bool SetInputAction(Func<string> Action, Button Btn) {
        return false;
    }

    public static bool InputExec(Button Btn){
        return false;
    }

    public static bool ChangeInputAction(){
        return false;
    }


}

