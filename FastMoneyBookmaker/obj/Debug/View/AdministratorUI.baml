   M S B A M L   `   `   `  ����M  IFastMoneyBookmaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FastMoneyBookmaker.ViewFastMoneyBookmaker.View  5      M+clr-namespace:FastMoneyBookmaker.ConvertersFastMoneyBookmaker.Converters  5      M+clr-namespace:FastMoneyBookmaker.ViewModelsFastMoneyBookmaker.ViewModels  5	      -    'FastMoneyBookmaker.View.AdministratorUI   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:FastMoneyBookmaker.View     5      <conv+clr-namespace:FastMoneyBookmaker.Converters     5      B
viewmodels+clr-namespace:FastMoneyBookmaker.ViewModels     5	        � 	Resources  5      <  6FastMoneyBookmaker.Converters.StringToBooleanConverter   StringToBoolean)  #System.Windows.Controls.DataGridRow �� 
TargetType 
 STYLE1 �� Triggers P� Property P� Value �� Property �� Value��%�   &	        &	        5   
   6(   �� 5   
   "  6    5      P� 5       �@ 
IsSelected . . �5      ��  � ��
 �  ��63   �� 5       � ��
 �����63   5      5      5      .��5   
   �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��7* �6   .+�5   
   �� 
������ $��Bottom=�6*   $��1��5      ��5      �� *MainVM.LogOutCommand+.��5!      ��  �� Orientation$ 
Horizontal=�6   .+�5"      �� 
�������$��22(�5$   $   $
��Bold"�5%   $   $��Center=�5&   $   $
��Left=�5'   $   �� 5)      $��/Resources/Icons/door.png��6   $��1��6;   $��64��5*       $��64��6/   $��Center=�5+       5-      5.      �� 5/   
   $��Refresh��6   $��Center=�50      ��5/   #   �� *SaveChangesCommand+50      �� 52      $��1��6   .@�54      ��   Matches#���  6   .��55      � .+�56      �� .+�57      &   System.Windows.Controls.DataGrid  	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    CanUserAddRows .     CanUserSortColumns . $   HorizontalScrollBarVisibility$ Disabled=�59         MinRowHeight$ 30Q�6<   ��57      �� *	Matches+   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<        Id,  &System.Windows.Controls.DataGridColumn   Header# �  61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   ��  �� Path$ Id�6k     5=        KindOfSport# �  61   $ 1* 6}    6X   �� $ KindOfSport�6}     5>        TeamName# �  61   $ 1* 6|    6U   �� $ Teams[0].Name�6|     5?      # �  61   $ 1* 6w    6U   �� *Teams[1].Name+6w   5A      1   +FastMoneyBookmaker.View.NewMatchUserControl  5C      5E      5F      5G      �� 5H       	 Users#���  6   .��5I        -   5        $��
MeDataGrid��5L      	 .  
 .   .   . $ Disabled=�5K      $ 30Q�6<   ��5I      �� *Users+  5N       
 Style1 
 Style2��%�   &	       &	 J     �� 5O      "  6    .�5P      ��  � ��
 �  ��6;   5Q      �� 5R      "  6    .�5S      ��  � ��
 � � �6;   5T      5U      ��5V      �� 5W      "  6    .�5X      ��  �@ RowStyle# [ 69    5Y      �� 5Z   "    �� Binding 6.   ��  �� ElementName$ 
MyDataGrid��$ DataContext.IsInLiveMode� �� Value True6x   .a�5[   &   ��  �@ RowStyle# [ 6A   5\   #   5^       5`        5a      # �  6-      
IsReadOnly . $
 0.3* 6y    6]   �� $ Id�6y     5b       	 Nickname# � 	 6-    . $ 1* 6�    6c   �� $ Nickname�6�     5c       
 Balance# � 
 6-   $ 1* 6q    6P   �� $ Balance�6q   4	  .System.Windows.Controls.DataGridCheckBoxColumn	  5d       .    Administrator# �  6D   $ 1* 6�    6m   �� $ IsAdministrator� �� Mode$ TwoWay=�6�   	  5e       .    Blocked# �  6D   $ 1* 6�    6g   �� $ 	IsBlocked�$ TwoWay=�6�   	  5f       .    	Confirmed# �  6D   $ 1* 6�    6i   �� $ IsConfirmed�$ TwoWay=�6�     5g       	 Email# �  6-    . $ 1* 6�    6`   �� $ Contact.Email�6�   5i      5k      5m      5n      5o      