   M S B A M L   `   `   `  ����E  APopupStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PopupStore
PopupStore  5          PopupStore.SellPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:PopupStore     5        N� Title$  SellPage��5	      .��5      � .+�5   
   ]� .+�5      �� .��5      �� .+�5      �� $��Ventes��6   $��10q�6/   $��10q�6;   $	��Top=�6H   .��5      �  � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   "   " ��6(   .�5   &   ��  � ��$ 0,0,0,10q�6?   �� 5   &    � ��$ 5,2,5,2q�6@   5   #   5      .+�5      �� -   5        .��5   4   	Supprimer6?   &   System.Windows.Controls.DataGrid  5      -   5          Name$ sellDataGrid��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5      	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 5      
   HeadersVisibility$
 Column=�5         
IsReadOnly$
 True��5       $
��True��5!      $
��Auto=�5"      ��5      �� *Sells+   Columns 5#   "   0  *System.Windows.Controls.DataGridTextColumn  5$   &   ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
Datetime+  5%   &   $ Type de paiement��69    6S   �� *PaymentType+  5&   &   $ Montant total��69    6P   �� *AmountTotal+5(      5)      5*      �� 5+      $��Détail de vente��6   $��10q�68   $��10q�6D   $��Bottom=�6Q   .��5,        $ False��5-      $ False��5.      $	 * 5/      $
 True��50      $
 Column=�51      $
��True��52      $
��Auto=�53      ��5,   #   �� *Sells/SellProductRels+ 54        55   "   $ Produit��65    6F   �� *Product.Name+  56   "   $ 	Quantité��65    6G   �� *
Quantity+  57   "   $ Prix unitaire��65    6L   �� *Product.Price.Value+59      5:      5;      5<      5=      5>      5?      