   M S B A M L   `   `   `  ����D  @ProjectHR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectHR.ViewsProjectHR.Views  5      )    #ProjectHR.Views.PageEmployeeHistory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectHR.Views     5        N� Title$  PageEmployeeHistory��5	      .��5      � 
����  � � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      �� 5      $��30 �6   .+�5   
   �� $��0��6   
����  �._�5      �� $��14(�6    �� TextAlignment$ Center=�5      $��Center=�5      
�������Employee changes history5      5      �� 5   
   $��1��6   $��2q�6   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      �� $��1��6   
����İ�$ 
Horizontal=�5       $��1q�66   .+�5!      �� ��6    �� *CurrentEmployee.Lastname+�� 5"      $�� ��6    �� 5#      ��6    �� *CurrentEmployee.Firstname+5$      �� 5%      $��2��6   
����İ�$ 
Horizontal=�5'      $��1q�5(      $��Right=�6(   .+�5)      �� $��[��6    �� 5*      ��6    �� *)'CurrentEmployee.CurrentDepartment.Title+�� 5+      $��]��6    5,      �� 5-      $��3��6   
����İ�$ 
Horizontal=�5/      $��1q�50      $��Right=�6(   .+�51      �� $��(��6    �� 52      ��6    �� *#!CurrentEmployee.Skill.Description+�� 53      $��)��6    54      55      56      �� 58   
   -   5        $��listBoxHistory��58      $��2��6(   $��Stretch=�65   ��59      �� 5:      .R�5;      �� $��2q�6   $��1q�6(   
�����F� �� CornerRadius$ 3��6T   ._�5<      � $��2q�6    5=      �� 5>   "   �� 5?   "   �� 5@   "    � ColumnDefinitions 5B      �� 5C   "   $��1* �63   �� 5D   "   $��6* �63   �� 5E   "   $��8* �63   �� 5F   "   $��8* �63   .+�5H      �� $ 
Horizontal=�6)   $��0��6B   $��0��6O   $��2��6_   .+�5I   "   �� $
��Bold"�6,   $��Date of change: ��6>   �� 5J   "   ��5K   (   �� *ChangeDateTime+5L      �� 5N      $��1��6(   $��1��65   $
��Bold"�6E   $��PropertyName��5O   (   �� 5P      $��1��6(   $��2��65   $
��Bold"�6E   $��OldValue��5Q   (   �� 5R      $��1��6(   $��3��65   $
��Bold"�6E   $��NewValue��5S   (   �� 5U      $��2��6(   $��1��65   ��5V   (   �� *PropertyName+�� 5W      $��2��6(   $��2��65   ��5X   (   �� *
OldValue+�� 5Y      $��2��6(   $��3��65   ��5Z   (   �� *
NewValue+5[      5\      5]      5_      �� 5`   
   $��3��6   
����  �._�5a      �  5b      �� 5c      $��3* �6'   �� 5d      $��1* �6'   .+�5f      �� $��5q�6   $��60��6$   $��1��5g      $��Right=�6)   ��5f   /   �� *ViewAllEmployees+.��5g   E   Back5i      5j      5k      5l      5m      