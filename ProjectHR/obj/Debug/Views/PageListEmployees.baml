   M S B A M L   `   `   `  ����D  @ProjectHR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectHR.ViewsProjectHR.Views  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5      '    !ProjectHR.Views.PageListEmployees   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectHR.Views     5      :s,clr-namespace:UIControls;assembly=UIControls     5        N� Title$  PageListEmployees��5
      .��5      � 
����  � � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $��2 �6   �� 5      $��* �6   �� 5      $��2 �6   .+�5   
   �� $��0��6   $��1��6   
����  �._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $��14(�6    �� TextAlignment$ Center=�5      $��Center=�5      
�������List of employees5       �� 5!      $��14(�6   $ Center=�5"      $��Center=�5#      
���������5$   /   ��  �� ElementName$ listBoxEmployees�� �� Path$ Items.Count� �� StringFormat$  [{0}]��5%      5&      �� 5'   
   $��1��6   $��1��6   
����  �$��4q�5(   '   $��Center=�62   ._�5)      � $��8,2,8,2q�6    5*      �� 5+      $	��10* �6'   �� 5,      $��4* �6'   �� 5-      $��4* �6'   �� 5.      $��1* �6'   .+�50      �� $��0��6   $ 
Horizontal=�6-   $��1q�6F   .+�51        UIControls.LabelUpDown  -   5        $��
lbLastname��51   $      	LabelText$ Lastname��66   
�������6K     52      -   5        $��lbFirstname��52   $   $ 	Firstname��67   
�������6M   53      �� 54      $��1��6   $ 
Horizontal=�6-   $��1q�55   1   $��Right=�6<   .+�56        -   5        $��lbDepartment��56   $   $ 
Department��68   
�������6O   57      �� 58      $��2��6   $ 
Horizontal=�6-   $��1q�59   1   $��Right=�6<   .+�5:        -   5        $��lbSkillLevel��5:   $   $ Skill��68   
�������6J   5;      5<      5=      �� 5>   
   -   5        $��myScrollViewer��5?      $��2��5>      $��1��6$   $��4q�5@      $��Stretch=�5A      $
��Auto=�5B      $
��Auto=�5C      .��5D      �� $��1��6   
�������._�5E      �� -   5        $��listBoxEmployees��5E      $��1��62   $��1��6?   $��Stretch=�5G      ��5H      �� 5I      .R�5J      �� $��2q�6%   $��1q�60   
�����F�	 �� CornerRadius$	 3��6\   ._�5K   "   � $��2q�6'    5L   &   �� 5M   *   $��6* �6;   �� 5N   *   $��2* �6;   �� 5O   *   $��2* �6;   .+�5Q   &   �� $��0��61   $ 
Horizontal=�6A   $��3q�6Z   .+�5R   *   �� ��64   �� *
Lastname+�� 5S   *   $�� ��64   �� 5T   *   ��64   �� *	Firstname+5U   '   �� 5V   &   $��1��61   $ 
Horizontal=�6A   $��3q�5W   1   $��Right=�6<   .+�5X   *   �� $��[��64   �� 5Y   *   ��64   �� *CurrentDepartment.Title+�� 5Z   *   $��]��64   5[   '   �� 5\   &   $��2��61   $ 
Horizontal=�6A   $��3q�5]   1   $��Right=�6<   .+�5^   *   �� $��(��64   �� 5_   *   ��64   �� *Skill.Description+�� 5`   *   $��)��64   5a   '   5b   #   5d      5e      5g      5h      5i      �� 5j   
   $��3��6   $��1��6   
����  �._�5k      �� $ 
Horizontal=�6   .+�5l      �� $��5q�6   $��75��6$   ��6/   �� *ViewDetails+.��6O   View details5n      �� 5o      $��5q�6   $��75��6$   ��6/   �� *EditEmployee+.��6P   Edit5q      �� 5r      $��5q�6   $��75��6$   ��6/   �� *TransferEmployee+.��6T   
Transfer5t      �� 5u      $��5q�6   $��75��6$   ��6/   �� *ViewHistory+.��6O   View history5w      5x      5y      5z      5{      