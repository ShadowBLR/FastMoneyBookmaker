   M S B A M L   `   `   `  ����M  IFastMoneyBookmaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FastMoneyBookmaker.ViewFastMoneyBookmaker.View  5      M+clr-namespace:FastMoneyBookmaker.ViewModelsFastMoneyBookmaker.ViewModels  5      &     FastMoneyBookmaker.View.MyBetsUI   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:FastMoneyBookmaker.View     5      :vm+clr-namespace:FastMoneyBookmaker.ViewModels     5      .��5      � .+�5   
   �� .+�5   
   &   System.Windows.Controls.DataGrid      AutoGenerateColumns  .     
IsReadOnly .     CanUserAddRows .     CanUserSortColumns . $   HorizontalScrollBarVisibility$ Disabled=�5         MinRowHeight$ 30Q�5         SelectionMode$ Single=�6%   ��5      �� *CurrentUser.Bets+ �� SelectedItem 5      �� *SelectedBet+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         Id,  &System.Windows.Controls.DataGridColumn	   Header#	 �   6!   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 0.3* 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Id+6V     5        	DateOfBet#	 �  6!   $
 1* 6d    6F   �� *	DateOfBet+6d     5        Cash#	 �  6!   $
 1* 6Z    6A   �� *Cash+6Z     5        
StateOfBet#	 �  6!   $
 1* 6a    6G   �� *State+6a     5        KindOfSport#	 �  6!   $
 1* 6n    6H   �� *Match.KindOfSport+6n   5      �� 5        BaseButtonTheme#��[ 6     
CancelABet#���  5      $��5q�5      $
��Left=�6!   $��5q�5       ��5      �� *CancelABetCommand+5       5"      5#      5$      