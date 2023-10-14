import javax.swing.*; // import the swing library for I/O
 class inputbox
{
 public static void main (String[] param)
 {
 askForFact();
 return;
 } // END main
 
 public static void askForFact()
 {
     String userfact = JOptionPane.showInputDialog
 ("Go on tell me something you believe!");
 JOptionPane.showMessageDialog(null,
 "So... you think..." + userfact + " do you");
 return;
 } // END askForFact
} // END class inputbox