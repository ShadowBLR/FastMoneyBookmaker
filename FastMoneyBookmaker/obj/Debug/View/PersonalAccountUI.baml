   M S B A M L   `   `   `  ����M  IFastMoneyBookmaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FastMoneyBookmaker.ViewFastMoneyBookmaker.View  5      M+clr-namespace:FastMoneyBookmaker.ViewModelsFastMoneyBookmaker.ViewModels  5      /    )FastMoneyBookmaker.View.PersonalAccountUI   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:FastMoneyBookmaker.View     5      :vm+clr-namespace:FastMoneyBookmaker.ViewModels     5        � 	Resources  5         
MenuButton �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%  &	        �� 5   
   " ��6#   .�5      ��  � ��$ 10q�6'   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 �����63   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��6* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   .+�5!   
   �� 
���   �$��3��6$   �� 5"   
   $��/Resources/Icons/logo.png��6   $��Center=�5#      � 5$   
   $��2��6    5%      �� 5&      �� 5'      .+�5)      �� $��0��6   
������ $��10q�5*      
�������$��Center=�5,      ��5/      �� 50      	 �� 
TargetType"	 ��6'   .R�51      � .+�52      A� 
�������66   �� 53      #��z��6$   $��Center=�54   (   $��Center=�55   (   56      57      5:      �� 5;      $��0��6   $��10q�6%   $��Right=�5<      $��Center=�5=      ��5?      �� 5@      "	 ��6'   .R�5A      � .+�5B      A� 
�������66   �� 5C      #��z��6$   $��Center=�6H   $��Center=�5D       5E      5F      5H      �� 5I      $��1��6   $��Right=�6*   .+�5J      �� $��1��6   $��Right=�6,   
���������6H   �� *CurrentUser.Nickname+5K      �� 5L      $��1��6   $��Right=�6,   
���������6H   �� *	Balance+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=�5M      5N      5P      �� 5Q   
   $��1��6   
���   �$
��auto��5R      $��Stretch=�5S      .+�5U      	�   Home#���  6   $��50��5V      $	��100��5W      
�������$��22(�5Y        MenuButtonTheme#��[ 5Z      $��Stretch=�5[      	� 5\       
 MyBets#���  6   $��50��5]      $	��100��5^      
�������$��22(�5`      #��[ 5a      $��Stretch=�5c      ��5b      �� *ShowMyBetsUI+5c      	� 5d        Matches#���  6   $��50��5e      $	��100��5f      
�������$��22(�5h      #��[ 5j      ��5i      �� *ShowMatchesUI+5j      	� 5k        Balance#���  6   $��50��5l      $	��100��5m      
�������$��22(�5o      #��[ 5p      ��5q      �� *ShowBalanceUICommand+	� 5s        	MyProfile#���  6   $��50��5t      $	��100��5u      
�������$��22(�5w      #��[ 5y      ��5x      �� *ShowMyProfileUI+5y      	� 5z        Settings#���  6   $��50��5{      $	��100��5|      
�������$��22(�5~      #��[ 5      ��5�      �� *ShowSettingsUI+5�      �� 5�      
������ $��Bottom=�63   $��1��5�      ��5�      �� *MainVM.LogOutCommand+.��5�      ��  �� Orientation$ 
Horizontal=�6!   .+�5�      �� 
�������$��22(�5�   $   $
��Bold"�5�   $   $��Center=�5�   $   $
��Left=�5�   $   �� 5�      $��/Resources/Icons/door.png��6    $��1��6C   $��64��5�       $��64��6/   $��Center=�5�       5�      5�      � 5�   
   $��1��6   $��1��6   ���#2e2c2c.+�5�      �� ���#2e2c2c��6   �� *
SelectedVM+5�      5�      5�      5�      