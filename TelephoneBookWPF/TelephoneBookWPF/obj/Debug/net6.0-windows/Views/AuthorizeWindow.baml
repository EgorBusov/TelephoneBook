   M S B A M L   `   `   `  ����K  GTelephoneBookWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TelephoneBookWPF.ViewsTelephoneBookWPF.Views  5   	   I)clr-namespace:TelephoneBookWPF.ViewModelsTelephoneBookWPF.ViewModels  5   	   ,    &TelephoneBookWPF.Views.AuthorizeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TelephoneBookWPF.Views     5   	   8vm)clr-namespace:TelephoneBookWPF.ViewModels     5   	   -   5          �Name$  
AuthWindow��5   	    � Title$ AuthorizeWindow��5
   	   $	��200��6!   $	��270��6.    � DataContext 5      :  4TelephoneBookWPF.ViewModels.AuthorizeWindowViewModel  5   
   .��5      � ���#FAEBD7.+�5   
   �� -   5         ��Name$ 	textLogin��5      ���#FFDEAD$��100,30,10,0q�5       �� TextWrapping$
 Wrap=�5      $	��Top=�5      $��2��5      ��5      �� *Login+�� 5   
   -   5        $ textPassword��5      ���#FFDEAD$��100,60,10,0q�5      $	��Top=�5      $��2��5      ��5      ��  �� Path$ Password��� 5   
   $��Username��6   ���#7FFFD4$
��Left=�5      $��	10,22,0,0q�5      $	��Top=�5      �� 5   
   $��Password��6   ���#7FFFD4$
��Left=�5      $��	10,56,0,0q�5       $	��Top=�5!      �� 5"   
   -   5         ��Name$ authorizationButton��5"      ���#7B68EE$��Login��5#      $��150,100,10,0q�5$      $	��Top=�5%      $��2��5&      ��5'      �� *LoginCommand+��5(      ��  �� ElementName$ 
AuthWindow���� 5)   
   -   5        $ registerButton��5)      ���#7B68EE$��Register��5*      $��10,100,150,0q�5+      $	��Top=�5,      $��2��5-      ��5.      �� *RegisterCommand+��5/      �� $ 
AuthWindow���� 50   
   -   5         ��Name$ error��50      
���  ��$��Center=�52      $��	0,129,0,0q�53      $	��Top=�54      $��15��55      $	��160��6   $��0q�56      ��57      �� *ErrorContent+�� 58   
   -   5        $ 
skipButton��58      ���#7B68EE$
��skip��59      $��
220,5,10,0q�5:      $��15��5;      $	��Top=�5<      $��2��5=      $��0q�5>      ��5?      �� *SkipCommand+��5@      �� $ 
AuthWindow��5A      5B      