using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.ShoppingCart
{
    public class SelectShoppingCartViewComponentPartial : ViewComponent
    {
        private readonly IProductService servise;
        private readonly ICartService cartService; 
             
        public SelectShoppingCartViewComponentPartial(IProductService productServise, ICartService CartService)
        {
            servise =  productServise;
            cartService = CartService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id,string Toplam) // Ürünün Id si , ShopDetails da ki eklenen ürünün miktarı
        {

            var User = Program.OnlineUser;                                                              // AccountController da Login/Register metodlarında eklediğim Kullanıcıyı buradaki User a ekliyorum 
            var Cart = await cartService.GetCartWithProductAsync(i => i.UserId == User.Id);             // Kullanıcıdan yola çıkarak kullanıcının sepetini buluyorum 
            var Product = await servise.GetByIdAsync(Id);                                                // Gelen ürünün Id siyle ürünü buluyorum 

            ViewBag.ToplamTutar = 0;
            
           


            if (Cart == null && Id == 0)  
            {
                Cart a = new Cart();
                a.UserId = User.Id;
                await cartService.CreateAsync(a);
                return View(a);

            }                                                                // Eğer Sepet yoksa ve sayfaya ürün eklemeden gelindiyse bi sepet oluşturulur ve boş sepet sayfaya gösterilir
            else if (Id == 0)  
            {
                return View(Cart);
            }                                                                           // Eğer sepet varsa ama sayfaya ürün eklemeden gelindiyse sepet gösterilir
            else if (Cart == null) 
            {
                int Productcount = Convert.ToInt32(Toplam);                                                  // ShopDetails da ki eklenen ürünün miktarını Productcount a ekliyorum
                Product.Stock = Product.Stock - Productcount;                                                // Eklenen miktarı Ürünün stoğundan çıkarıyorum 
                await servise.UpdateAsync(Product);                                                          // Stoğu azaltılmış ürünü güncelliyorum 

                Cart a = new Cart();  // Sepet oluşturulur 

                CartProduct CartProduct = new CartProduct(); // Sepete eklenmek üzere CartProduct oluşturlır
                CartProduct.Product = Product;
                CartProduct.ProductId = Product.Id;
                CartProduct.ProductCount = Productcount;

                a.UserId = User.Id;
                a.CartProducts.Add(CartProduct); 

                await cartService.CreateAsync(a);
                return View(a);

            }                                                                      // Eğer sepet yoksa ve sayfaya ürünü sepete ekle butonu ile gelindiyse Sepet oluşturlur ve seçilen ürün sayfaya gönderilir
            else 
            {
                int Productcount = Convert.ToInt32(Toplam);                                                  // ShopDetails da ki eklenen ürünün miktarını Productcount a ekliyorum
                Product.Stock = Product.Stock - Productcount;                                                // Eklenen miktarı Ürünün stoğundan çıkarıyorum 
                await servise.UpdateAsync(Product);                                                          // Stoğu azaltılmış ürünü güncelliyorum 


                var Mevcuturun = Cart.CartProducts.Where(cp => cp.ProductId == Product.Id).FirstOrDefault(); // Ürün sepette varmı işlemi    

                if (Mevcuturun != null)
                {
                    Mevcuturun.ProductCount += Productcount;
                }
                else
                {
                    CartProduct CartProduct = new CartProduct();
                    CartProduct.Product = Product;
                    CartProduct.ProductId = Product.Id;
                    CartProduct.Cart = Cart;
                    CartProduct.ProductCount = Productcount;
                    Cart.CartProducts.Add(CartProduct);
                }


                await cartService.SaveChanges();
                return View(Cart);
            }                                                                                        // Eğer Sepet varsa ve Kullanıcı ürünü sepete ekle butonu ile sayfaya geldiyse önce ürün mevcut sepette varmı diye bakılır varsa ürünün sayısı eklenir yoksa o ürün sepete eklenir ve sayfaya sepet gösterilir 

           
        }
    }
}

/*
    Stock güncelleme → Şu an her seferinde Product.Stock azalıyor, ama aynı ürün tekrar eklenirse yine eksiliyor. Mantığı dikkatlice kontrol et.

    Kod tekrarı → CartProduct yaratma kısmı 2 yerde var, bunu bir yardımcı method ile toplamak daha temiz olur.
*/