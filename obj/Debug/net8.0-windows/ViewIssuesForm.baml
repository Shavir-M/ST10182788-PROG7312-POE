   M S B A M L   `   `   `  ����  Programming 3B Part 1*    $Programming_3B_Part_1.ViewIssuesForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  View Reported Issues��5   	    � WindowStartupLocation$ CenterScreen=�5   	      BackgroundBrush#��[  5   	     	TextBrush#��[ 5   	    � 	Resources 5	      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  PrimaryBrush �� Triggers P� Property P� Value)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%�  '        7  '  �    '  �    �� 5   
   "  6   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��
 �   �6+   �� 5       � ��8   6+   �� 5       � ��$ Center=�6;   �� 5       � ��
 �   �6,   �� 5       � ��$ 1q�60    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 ����63   �� 5       � ��
 �   �63   5      5      �� 5!   
   "  6   .�5"      ��  � ��
 �����6+    5#      P� 5$       �@ 
IsSelected$
 True��60   . �5%      ��  � ��
 ����63   �� 5'       � ��
 �   �63   5)      P� 5*       �@J�IsMouseOver$
 True��61   . �5+      ��  � ��
 �����63   5-      5/      �� 52   
   "  6   .�53      ��  � ��
 �   �6,   �� 54       � ��$	 0.5q�60   �� 55       � ��$ 5q�6(   56      57      .��59      � .+�5;   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataGridIssues��5;      
   AutoGenerateColumns$
 False��5<         CanUserSortColumns$
 True��5=      $��10,10,10,50q�5>         
IsReadOnly$
 True��5?         AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�5A      
���   �$��1q�5C      
�������
���   �   	RowHeight$ 30Q�5G         HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Location��6%      SortMemberPath$ Location��5N   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5O   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   %   �� *
Location+5O   %     5P      $ Category��6%   $ Category��5R   %   $ * 5S   %    5Q   %   �� *
Category+5S   %     5T      $ Description��6%   $ Description��5V   %   $ 2* 5W   %    5U   %   �� *Description+5W   %   4	  .System.Windows.Controls.DataGridTemplateColumn	  5Z      $ Attached Files��6)   $ 2* 6A    	  CellTemplate 5[      �� 5\      .R�5]      �� ��6+   �� *AttachedFiles+��5^   "   �� 5_   &   .R�5`   *   �� �� 5a   .   -   5        ��5a   8   �� *.+.�6~   .�5b   2   �� #��[ 6O   ��6<   �� *.+6O   5c   /   5d   +   5e   '   5g      5h      5j        5m      $ 
Importance��6%   $ 
Importance��5o   %   $ * 5p   %    5n   %   �� *
Importance+5p   %   	  5r      $ Mark as Important��6)    5s      �� 5t      .R�5u      �� -   5        $��Upvote��5u   %   #��[ 5x   %   #��[ 5y   %   
 � Tag 5w   %   �� *Id+5y   %   5z      5|      5~      �� 5�   
   -   5        $��Back to Main Menu��5�      $��Right=�5�      $��Bottom=�5�      $��10q�5�      $	��150��5�      #��[ 5�      #��[ 5�      5�      5�      5�      