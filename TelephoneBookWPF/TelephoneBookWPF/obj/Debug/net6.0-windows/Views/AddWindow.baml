   M S B A M L   `   `   `  ����K  GTelephoneBookWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TelephoneBookWPF.ViewsTelephoneBookWPF.Views  5   	   I)clr-namespace:TelephoneBookWPF.ViewModelsTelephoneBookWPF.ViewModels  5   	   &     TelephoneBookWPF.Views.AddWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TelephoneBookWPF.Views     5   	   8vm)clr-namespace:TelephoneBookWPF.ViewModels     5   	   -   5          �Name$  AWindow��5   	    � Title$ 	AddWindow��5
   	   $	��320��6   $	��500��6(    � DataContext 5      4  .TelephoneBookWPF.ViewModels.AddWindowViewModel  5   
   .��5      � ���#FAEBD7.+�5   
   �� -   5         ��Name$ textSurName��5      $
��Left=�6'   $��
150,20,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $	��Top=�5      $	��150��6*   $��25��66   ���#FFDEAD��6W   �� *Persone.SurName+�� 5   
   -   5        $ textName��5      $
��Left=�6$   $��
150,65,0,0q�6?   $
 Wrap=�6S   $	��Top=�5      $	��150��6*   $��25��66   ���#FFDEAD��6W   �� *Persone.Name+�� 5   
   -   5        $ textFatherName��5      $
��Left=�6*   $��150,110,0,0q�6E   $
 Wrap=�6Z   $	��Top=�5      $	��150��6*   $��25��66   ���#FFDEAD��6W   �� *Persone.FatherName+�� 5   
   -   5        $ textTelephone��5      $
��Left=�6)   $��150,155,0,0q�6D   $
 Wrap=�6Y   $	��Top=�5      $	��150��6*   $��25��66   ���#FFDEAD��6W   �� *Persone.Telephone+�� 5   
   -   5        $ textAddress��5      $
��Left=�6'   $��150,200,0,0q�6B   $
 Wrap=�6W   $	��Top=�5      $	��150��6*   $��25��66   ���#FFDEAD��6W   �� *Persone.Address+�� 5   
   -   5        $ textDescription��5      $
��Left=�6+   $��150,245,0,0q�6F   $
 Wrap=�6[   $	��Top=�5      $	��150��6*   $��25��66   ���#FFDEAD��6W   �� *Persone.Description+�� 5   
   $��Surname��6   $��Right=�6"   $��
0,20,380,0q�6>   $	��Top=�5      $��20(�6(   $��0q�66   ���#7FFFD46B   �� 5   
   $
��Name��6   $��Right=�6   $��
0,65,380,0q�6;   $	��Top=�5      $��20(�6(   $��0q�66   ���#7FFFD46B   �� 5   
   $��
Fathername��6   $��Right=�6%   $��0,110,380,0q�6A   $	��Top=�5       $��20(�6(   $��0q�66   ���#7FFFD46B   �� 5!   
   $��	Telephone��6   $��Right=�6$   $��0,155,380,0q�6@   $	��Top=�5"      $��20(�6(   $��0q�66   ���#7FFFD46B   �� 5#   
   $��Address��6   $��Right=�6"   $��0,200,380,0q�6>   $	��Top=�5$      $��20(�6(   $��0q�66   ���#7FFFD46B   �� 5%   
   $��Description��6   $��Right=�6&   $��0,245,380,0q�6B   $	��Top=�5&      $��20(�6(   $��0q�66   ���#7FFFD46B   �� 5'   
   -   5         ��Name$ 	addButton��5'      $	��Add��6$   $��20(�62   $��Stretch=�6@   ���#7B68EE$��400,210,30,30q�5(      $��Stretch=�6(   ��5)      �� *
AddCommand+��60   ��  �� ElementName$ AWindow���� 5*   
   -	   5         ��Name$ error��5*      
���  ��$
��Left=�5,      $��320,110,0,0q�5-      $	��Top=�5.      $��90��5/      $	��160��6   $��0q�50      ��51      �� *ErrorContent+52      53      