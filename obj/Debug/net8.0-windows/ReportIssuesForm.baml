   M S B A M L   `   `   `  ����  Programming 3B Part 1,    &Programming_3B_Part_1.ReportIssuesForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Report an Issue��5   	    � WindowStartupLocation$ CenterScreen=�5   	      BackgroundBrush#��[  5   	   .��5	      ]� $
��True��6   $��20q�6%   .+�5   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��Center=�6F   $��0,20,0,0q�6c   .+�5      �� -   5         ��Name$ btnAttachFile��5      $��Attach Files��6,   $	��120��6C   $
��10,0q�6O     PrimaryBrush#��[ 6]   
�������6�   �� 5      -   5        $ 	btnSubmit��5      $��Submit��6(   $	��120��69   $
��10,0q�6E   #��[ 6S   
�������6�   �� 5      -   5        $ btnBackToMenu��5      $��Back to Main Menu��6,   $	��200��6H   $��50��6T   $
��10,0q�6`   #��[ 6n   
�������6�   5      �� 5   
   $��
300,0,0,20q�6   $	��400��6)   $	��500��65   .+�5      �� $��Report an Issue��6     PageHeading#��[ 6/   $��56��6T    �� TextAlignment$ Center=�6`   $	��276��6w   �� 5      $��	Location:��6   $
��Left=�6(   
���   �$��35��6V   $��20(�6b   �� 5      -   5         ��Name$ txtLocation��5      $	��300��6+   
�������
���   �6]   �� 5"      $��	Category:��6   $
��Left=�6(   
���   �$��0,20,0,0q�6V   $��35��6h   $��20(�6t   �� 5#      -   5         ��Name$ categoryComboBox��5#      $	��300��61   .@�5$      �� $��
Sanitation��6   �� 5%      $��Roads��6   �� 5&      $��	Utilities��6   �� 5'      $��Public Safety��6   �� 5(      $��Environmental��6   5)      �� 5,      $��Description:��6   $
��Left=�6+   
���   �$��0,20,0,0q�6Y   $��38��6k   $��20(�6w   �� 5-      -   5         ��Name$ rtbDescription��5-      $	��300��62   $	��100��6>   
�������
���   �6q   �� 50      -   5         ��Name$ lblFeedback��50      $!��Please fill in the details.��6)   $
��Left=�6O   
���   �$
��Bold"�6}   $��0,20,0,0q�6�   $��15(�6�   � 51      -   5        	 �Name$	 progressBarFormFilling��51      $	��300��6:   $��20��6F   
 � Minimum$
 0Q�6R    � Maximum$	 100Q�6^    � Value$ 0Q�6l   54      �� 57   
   -	   5         ��Name$ OverlayStack��57      
������� J� Opacity$	 0.8Q�6B   $y�	Collapsed=�6P   $��Center=�6g   $��Center=�6�   .+�58      �� $ ��Submitting, please wait...��6   $��Center=�6:   $��16(�6W   $
��Bold"�6e   $��0,0,0,20q�6w   � 59      -
   5        $	 progressBarOverlay��59      $	��300��66   $��25��6B   $
 0Q�6N   $	 100Q�6Z   5:      5;      5<      