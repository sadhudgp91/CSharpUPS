   M S B A M L   `   `   `  ����J  FUPSCustomerData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:UPSCustomerDataUPSCustomerData  5   	       UPSCustomerData.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:UPSCustomerData     5   	     � Title$  User Management��5   	   $��379.49��6!   $��482.797��61    � Icon$ Ups.ico��6A    � WindowStartupLocation$ CenterScreen=�6P   .��5	      � $��	10,0,15,9q�6    � RowDefinitions 5
   
   �� 5      $
��144* �6   �� 5      $	��24* �6   �� 5      $	��25* �6   �� 5      $
��172* �6   .+�5   
   �� -   5         ��Name$ txtName��5      $
��Left=�6#   $��25��6>   $��	89,14,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��320��6�   $��2��6�   $��1��6�   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��25��6?   $��89,7,0,0q�6K   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��320��6�   $��3��6�   �� 5   
   -   5         ��Name$ Add_User��5      $��Add User��6#   $
��Left=�66   $��36��6Q   $��
291,89,0,0q�6]   $	��Top=�6q   $	��118��6�   $��15(�6�   $��3��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��25��6:   $��	30,14,0,0q�6F   $	��Top=�6Y   $��79��6q   $��2��6|   $��1��6�   �� 5   
   $��Email��6   $
��Left=�6    $��25��6;   $��30,7,0,0q�6G   $	��Top=�6Y   $��79��6q   $��3��6|   �� 5   
   $��Gender��6   $
��Left=�6!   $��25��6<   $��	30,56,0,0q�6H   $	��Top=�6[   $��79��6s   $��3��6~   �� 5   
   $��Status��6   $
��Left=�6!   $��25��6<   $��
30,102,0,0q�6H   $	��Top=�6\   $��79��6t   $��3��6   �� 5   
   -   5         ��Name$ 	cmbGender��5      $
��Left=�6&   $��25��6A   $��	89,56,0,0q�6M   $	��Top=�6`   $	��144��6x   $��3��6�   .@�5      �� .��6   Male6!   �� 5       �� 
IsSelected . .��6-   Female65   5      �� 5   
   -   5        $ 	cmbStatus��5      $
��Left=�6&   $��25��6A   $��
89,102,0,0q�6M   $	��Top=�6a   $	��144��6y   $��3��6�   .@�5      �� .��6   
InActive6%   �� 5       . .��6-   Active65   5      �� 5    
   $��161,10,168,10q�6   $��
avatar.png��6'   $
��Fill=�6;   	 J� RenderTransformOrigin$	 0.432,0.218&�6J   5"      5#      