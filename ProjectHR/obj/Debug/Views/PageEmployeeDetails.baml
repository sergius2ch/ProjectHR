   M S B A M L   `   `   `  ����  	ProjectHR)    #ProjectHR.Views.PageEmployeeDetails   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  PageEmployeeDetails��5       � 	Resources 5	       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� Path	 �� Self
 �� RelativeSource �� DataType-  'System.Windows.Controls.ValidationError �� Binding �� Value��%�  '��       '�� �     (�� �    5      *, +)'�� #    '�� �    �� 5
   
   " ��6   .�5      ��  � ��
 ���� 6+    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 ��� �63   5      5      �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� $2 ,(Validation.Errors).CurrentItem.ErrorContent�#
 Z	 �� 5       � ��
 �P��63   5      5      �� 5   
   "  6   .R�5      �� 
���  ��$��Italic$�5      ��5       �� $ ErrorContent�5#      5$      �� 5&   
   " ��6   .�5'      ��  � y�$ Visible=�6+    5(      �� 5)       6   �� *	IsVisible+ True6<   .a�5*      ��  � y�$ Visible=�63   5+      5-      �� 5/   
   " ��6   .�50      ��  � ��
 �   �6+    51      P� 52       � {� .  . �53      ��  � ��
 �����63   54      56      57      .��59      � 
����  � � RowDefinitions 5:   
   �� 5;      $��30 �6   �� 5<      �� 5=      $��30 �6   .+�5?   
   �� $��0��6   
����  �._�5@      �� $��14(�6    �� TextAlignment$ Center=�5A      $��Center=�5B      
�������Employee Details5E      5F      �� 5G   
   -   5        $��myScrollViewer��5H      $��1��5G      $��4q�5I      $��Stretch=�5J      $
��Auto=�5K      $
��Auto=�5L      .��5M      �� $��1��6   
�������._�5N      �� .+�5O      �� .��6   Id6    �� 5P      
�������$��5q�67   ��5Q   $   �� *CurrentEmployee.Id+�� 5R      
�������$��2q�64   $��2q�6H   ._�5S      ��  �� Orientation$ Vertical=�6%   .+�5T      �� .��6$   	Firstname6/   �� 5U      -   5        $
��tbFn��5U   1   $��5q�6&   {�5V   &   �� *!CurrentEmployee.CanChangeBasics+��5W   &   �� *CurrentEmployee.Firstname+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . �� 5X      ��6/   ��  �� ElementName$
 tbFn��$% (Validation.Errors).CurrentItem�5Y      5Z      �� 5\      
�������$��2q�64   $��2q�6H   ._�5]      �� $ Vertical=�6%   .+�5^      �� .��6$   
Secondname60   �� 5_      -   5        $
��tbSn��5_   1   $��5q�6&   {�5`   &   �� *!CurrentEmployee.CanChangeBasics+��5a   &   �� *CurrentEmployee.Secondname+$ TwoWay=�$ PropertyChanged=� . �� 5b      ��6/   �� $
 tbSn��$% (Validation.Errors).CurrentItem�5c      5d      �� 5f      
�������$��2q�64   $��2q�6H   ._�5g      �� $ Vertical=�6%   .+�5h      �� .��6$   
Lastname6.   �� 5i      -   5        $
��tbLn��5i   1   $��5q�6&   {�5j   &   �� *!CurrentEmployee.CanChangeBasics+��5k   &   �� *CurrentEmployee.Lastname+$ TwoWay=�$ PropertyChanged=� . �� 5l      ��6/   �� $
 tbLn��$% (Validation.Errors).CurrentItem�5m      5n      �� 5p      
�������$��2q�64   $��2q�6H   ._�5q      �� $ Vertical=�6%   .+�5r      �� .��6$   
Birthday6.   (  "System.Windows.Controls.DatePicker  5s      -   5        $	��dpB��5s   4   $��5q�6)   {�5t   )   �� *!CurrentEmployee.CanChangeBasics+   SelectedDate 5u   )   �� *CurrentEmployee.Birthday+$ PropertyChanged=� . �� 5v      ��6/   �� $	 dpB��$% (Validation.Errors).CurrentItem�5w      5x      �� 5z      
�������$��2q�64   $��2q�6H   ._�5{      �� $ Vertical=�6%   .+�5|      �� .��6$   EmploymentDate64     5}      -   5        $	��dpE��5}   4   $��5q�6)   {�5~   %   �� *)'CurrentEmployee.CanChangeEmploymentDate+ 5   %   �� * CurrentEmployee.EmploymentDate+ . �� 5�      ��6/   �� $	 dpE��$% (Validation.Errors).CurrentItem�5�      5�      �� 5�      
�������$��2q�64   $��2q�6H   ._�5�      �� $ Vertical=�6%   .+�5�      �� .��6$   ProbationPeriod65   �� 5�      -   5        $	��cbP��5�   2   $��5q�6'    �� DisplayMemberPath$ DurationInMonth��5�   #   {�5�   #   �� *$"CurrentEmployee.CanChangeProbation+ �� SelectedValue 5�   #   �� *!CurrentEmployee.ProbationPeriod+ . ��5�   #   �� *Data.ProbationPeriods+5�   #   �� 5�      ��6/   �� $	 cbP��$% (Validation.Errors).CurrentItem�5�      5�      �� 5�      
�������$��2q�64   $��2q�6H   ._�5�      �� $ Vertical=�6%   .+�5�      �� .��6$   
Department60   �� 5�      -   5        $	��cbD��5�   2   $��5q�6'   $ Title��5�   #   {�5�   #   �� *%#CurrentEmployee.CanChangeDepartment+ 5�   #   �� *#!CurrentEmployee.CurrentDepartment+ . ��5�   #   �� *Data.Departments+5�   #   �� 5�      ��6/   �� $	 cbD��$% (Validation.Errors).CurrentItem�5�      5�      �� 5�      
�������$��2q�64   $��2q�6H   ._�5�      �� $ Vertical=�6%   .+�5�      �� .��6$   Skill6+   �� 5�      -	   5        $	��cbS��5�   2   $��5q�6'   $ Description��5�   #   {�5�   #   �� * CurrentEmployee.CanChangeSkill+ 5�   #   �� *CurrentEmployee.Skill+ . ��5�   #   �� *Data.SkillLevels+5�   #   �� 5�      ��6/   �� $	 cbS��$% (Validation.Errors).CurrentItem�5�      5�      5�      5�      5�      �� 5�   
   $��2��6   
����  �._�5�      �  � ColumnDefinitions 5�      �� 5�      $��3* �6'   �� 5�      $��1* �6'   .+�5�      �� $��0��6   $ 
Horizontal=�6-   .+�5�      �� $��5q�6   $��60��6(   ��5�      �� *SaveEmployee+.��6>   Add5�      �� 5�      $��5q�6   $��60��6(   ��5�      �� *UpdateEmployee+.��6@   Update5�      �� 5�      $��5q�6   $��60��6(   ��5�      �� *UndoEmployee+.��6>   Undo5�      5�      �� 5�      $��5q�6   $��60��6$   $��1��5�      $��Right=�6)   ��5�   /   �� *ViewAllEmployees+.��5�   E   Back5�      5�      5�      5�      5�      