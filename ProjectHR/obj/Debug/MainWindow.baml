   M S B A M L   `   `   `  ����D  @ProjectHR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProjectHR	ProjectHR  5   	   E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5   	       ProjectHR.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ProjectHR     5   	   :s,clr-namespace:UIControls;assembly=UIControls     5   	     � Title$  
HR Project��5	   	   $	��500��6   $	��570��6,   .��5
      �  � RowDefinitions 5   
   �� 5      $��64 �6   �� 5      �� 5      $��25 �6    � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5      �� 5      $��10 �6   .+�5   
   �� $��Images/HR-logo.png��6   �� 5   
   $��0��6   $��1��6%    �� Orientation$ Vertical=�62   .+�5      �� $��5q�6   
������  � ToolTip$ Show/Hide Logger window��5      ��5      �� *SwitchLogMonitor+.��5      �� $��Images/Icon-Log.png��6   5      �� 5      $��5q�6   
������ $% Export employees from xls sheet��5!      ��5       �� *SelectExcelFile+.��5"      �� $��Images/XlsImport.png��6   5#      d� 5$      $��5q�6   
������ $&  Show/Hide search and filter mode��5%      ��5&      �� *
SearchMode+.��5'      �� $��Images/Search.png��6   5(      �� 5)      $��5q�6   
������ $ Hire a new employee��5*      ��5+      �� *NewEmployee+.��5,      �� $��Images/Add.png��6   5-      5.       � 50   
   -   5        $��searchFrame��50      $��2q�51      $��1��6     � Source$ Views/PageSearch.xaml?�6+     � NavigationUIVisibility$ Hidden=�6J    � 53   
   -   5        $��	mainFrame��53      $��2q�54      $��1��6   $��1��6(   $ Hidden=�55      $" Views/PageListEmployees.xaml?�56      58      �� 5:   
   -   5        $��statusBorder��5:      $��3��6%   $��3��62   $��Stretch=�5;      
�������._�5=      �  5>      �� 5?      �� 5@      $��20 �6'   .+�5B      � -   5        $��progressBar��5B   )   $��2q�6   $��Stretch=�6<   $y�Hidden=�6Z   �� 5C      $��1��6   $��Right=�6-   5D      5E      5G      5H      