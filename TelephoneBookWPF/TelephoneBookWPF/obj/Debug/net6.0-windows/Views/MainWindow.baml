   M S B A M L   `   `   `  ����K  GTelephoneBookWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TelephoneBookWPFTelephoneBookWPF  5   	   I)clr-namespace:TelephoneBookWPF.ViewModelsTelephoneBookWPF.ViewModels  5   	   !    TelephoneBookWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TelephoneBookWPF     5   	   8vm)clr-namespace:TelephoneBookWPF.ViewModels     5   	   -   5          �Name$  MWindow��5   	    � Title$ 
MainWindow��5
   	   $	��450��6   $	��800��6)    � DataContext 5      5  /TelephoneBookWPF.ViewModels.MainWindowViewModel  5   
   .��5      � ���#FAEBD7 � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   �� -   5         ��Name$ listViewPersones��5      $��1��6-   $��1��6:   ���#FFDEAD��5      ��  �� Path$ Persones� �� SelectedItem 5      �� *SelectedItem+ � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%X   '��       �� 5      "	 ��6   .�5      �� 
 � �� �#7FFFD463   5      5        �� View 5!      �� 5"      .P�5#      �� $��Id��6N    �� Width$ 30��6Z    �� DisplayMemberBinding 6%   �� $ Id�6Z   �� 5$      $��Surname��6S   $	 120��6d    6%   �� $ SurName�6d   �� 5%      $
��Name��6P   $	 120��6^    6%   �� $
 Name�6^   �� 5&      $��
Fathername��6V   $	 120��6j    6%   �� $ 
FatherName�6j   5'       � ContextMenu 5)      �� 5*      -   5         ��Name$ listViewContextMenu��5*      .@�5+      m� -   5         m�Name$ menuItemEdit��5+      $
��Edit��65    m� Command 6C   �� *EditCommand+m� 5,      -   5        $ menuItemDelete��5,      $��Delete��67    6G   �� *DeleteCommand+5-      5/      ]� 50   
   $��0��6   $��0��6!   .+�51      �� -   5         ��Name$ 	addButton��51      $��5,0,20,0q�6(   $��0��6:   $��0��6G   ���#7B68EE$��50��52      $
��Left=�6    $	��Add��6;   $��15(�6I   ��6W   �� *AddPersoneCommand+�� 53      -   5        $ logoutButton��53      $��0,0,20,0q�6+   $��0��6=   $��0��6J   ���#7B68EE$��50��54      $
��Left=�6    $��Logout��6;   $��15(�6L   ��6Z   �� *LogoutCommand+��6|   ��  �� ElementName$ MWindow���� 55      -   5        $ usersButton��55      $��0,0,5,0q�6*   $��0��6;   $��0��6H   ���#7B68EE$��50��56      $
��Left=�6    $��Users��6;   $��15(�6K   ��6Y   �� *UsersCommand+57      �� 58   
   -	   5         ��Name$ error��58      $��1��6   $��0,0,0,0q�6/   $��Stretch=�6@   $��Stretch=�6\   
���  ��$��15(�59   !   $��0q�6/   ��6;   �� $ ErrorContent�]� 5:   
   $��2��6   $��0��6$   .+�5;      �� -
   5        $ updateButton��5;      $��2��6+   $��Update��6;   $
��Left=�6L   ���#7B68EE$��0,0,0,0q�5<      $��Stretch=�6&   $��15(�6B   ��6P   �� *InitPersonesCommand+5=      5>      5?      