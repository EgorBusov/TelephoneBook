   M S B A M L   `   `   `  ����K  GTelephoneBookWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TelephoneBookWPF.ViewsTelephoneBookWPF.Views  5   	   I)clr-namespace:TelephoneBookWPF.ViewModelsTelephoneBookWPF.ViewModels  5   	   (    "TelephoneBookWPF.Views.UsersWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TelephoneBookWPF.Views     5   	   8vm)clr-namespace:TelephoneBookWPF.ViewModels     5   	   -   5          �Name$  UWindow��5   	    � Title$ UsersWindow��5
   	   $	��450��6   $	��800��6*    � DataContext 5      6  0TelephoneBookWPF.ViewModels.UsersWindowViewModel  5   
   .��5      � ���#FAEBD7 � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   �� -   5         ��Name$ listViewUsers��5      $��1��6*   $��1��67   ���#FFDEAD��5      �� *Users+ �� SelectedItem 5      �� *SelectedUser+ � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%X   '��       �� 5      " ��6   .�5      �� 	 � ��
 �#7FFFD463   5      5        �� View 5!      �� 5"      .P�5#      �� $��Username��6O    �� Width$	 200��6a    �� DisplayMemberBinding 6%   �� *
Username+6a   �� 5$      $
��Role��6K   $	 200��6Y    6%   �� *Role+6Y   5%       � ContextMenu 5'      �� 5(      -   5         ��Name$ listViewContextMenu��5(      .@�5)      m� -   5         m�Name$ menuItemDelete��5)      $��Delete��67    m� Command 6G   �� *DeleteCommand+5*      5,      �� 5-   
   -   5         ��Name$ 
backButton��5-      $
��Back��6%   $��Stretch=�64   $��
10,5,130,5q�6R   $��Stretch=�5.      ���#7B68EE��6B   �� *CloseCommand+��6c   ��  �� ElementName$ UWindow���� 5/   
   -   5         ��Name$ error��5/      $��1��6   $��0,0,0,0q�6/   $��Stretch=�6@   $��Stretch=�6\   
���  ��$��15(�50   !   $��0q�6/   ��6;   �� *ErrorContent+51      52      