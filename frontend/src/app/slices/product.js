import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { ProductData } from "../data/ProductData";
import Swal from "sweetalert2";
import axios from "axios";

export const fetchProducts = createAsyncThunk("fetchProducts", async () => {
  const res = await axios.get("https://localhost:5050/api/products");
  return res;
});

export const fetchCart = createAsyncThunk("fetchCart", async (id) => {
  const res = await axios.get(`https://localhost:5050/api/cart/GetCart/${id}`);
  return res;
});

const productsSlice = createSlice({
  name: "products",
  initialState: {
    products: [],
    carts: {
      cartHeader: {},
      cartDetails: [],
    },
    favorites: ProductData.slice(1, 4),
    single: null, // her bir ürün temsil edelrx
  },
  reducers: {
    //sepete ürün eklemek için kullanılacak
    AddToCart: (state, action) => {
      let { val, id } = action.payload;
      let sepeteEklenecekUrun = state.carts.cartDetails.find(
        (item) => item.product.id === parseInt(id)
      );
      if (sepeteEklenecekUrun === undefined) {
        //sepete eklemek istediğim ürün bilgilerine getirecek ilgili rest servisi çağırılır
        let item = state.products.find((item) => item.id === parseInt(id));
        /* const cart = {
          ...state.carts,
        }; */
        const cartDetail = {
          cartDetailsId: null,
          cartHeader: state.carts.cartHeader,
          cartHeaderId: state.carts.cartHeader.cartHeaderId,
          product: item,
          productId: id,
          count: 1,
        };
        state.carts.cartDetails.push(cartDetail);

        console.log("Auth Header: ", axios.defaults.headers.common);
        axios
          .post("https://localhost:5050/api/cart", state.carts, {
            headers: {
              "Content-Type": "application/json",
            },
          })
          .then((response) => {
            // response.data.result değerini kullanarak state.carts'ı güncelle
            /* state.carts = response.data.result; */
            console.log("Updated Cart : ", response.data.result);
          })
          .catch((error) => {
            console.error("Cart update error:", error);
          });

        /* item.quantity = 1;
        state.carts.push(item);
        Swal.fire({
          title: "Başarılı",
          text: "Ürün sepete eklendi!",
          icon: "success",
          showConfirmButton: false,
          timer: 2000,
        }); */
      } else {
        state.carts.cartDetails.forEach((item) => {
          if (item.productId === parseInt(id)) {
            item.count = parseInt(val);
          }
        });

        // axios.post ile isteği gönder ve .then() zinciriyle sonuçları işle
        axios
          .post("https://localhost:5050/api/cart/UpdateCart", state.carts)
          .then((response) => {
            // response.data.result değerini kullanarak state.carts'ı güncelle
            state.carts = response.data.result;
          })
          .catch((error) => {
            console.error("Cart update error:", error);
          });
      }
    },
    getProductById: (state, action) => {
      let { id } = action.payload;
      let urunDetay = state.products.find((item) => item.id === parseInt(id));
      state.single = urunDetay;
    },
    updateCart: (state, action) => {
      const { val, id } = action.payload;

      // state.carts.cartDetails içindeki item'ların count değerlerini güncelle
      state.carts.cartDetails.forEach((item) => {
        if (item.productId === parseInt(id)) {
          item.count = parseInt(val);
        }
      });

      // axios.post ile isteği gönder ve .then() zinciriyle sonuçları işle
      axios
        .post("https://localhost:5050/api/cart/UpdateCart", state.carts)
        .then((response) => {
          // response.data.result değerini kullanarak state.carts'ı güncelle
          state.carts = response.data.result;
        })
        .catch((error) => {
          console.error("Cart update error:", error);
        });
    },
    removeCart: (state, action) => {
      let { id } = action.payload;
      let sepetinOnSonHali = state.carts.cartDetails.filter(
        (item) => item.cartDetailsId !== parseInt(id)
      );
      // axios.post ile isteği gönder ve .then() zinciriyle sonuçları işle
      axios
        .post(`https://localhost:5050/api/cart/RemoveCart/${parseInt(id)}`)
        .then((response) => {
          state.carts = sepetinOnSonHali;
        })
        .catch((error) => {
          console.error("Cart remove error:", error);
        });
    },
    //sepeti comple silmek için
    clearCart: (state) => {
      state.carts = [];
    },
    addToFavorites: (state, action) => {
      let { id } = action.payload;
      let item = state.favorites.find((item) => item.id === parseInt(id));
      if (item === undefined) {
        let urunFavori = state.products.find(
          (item) => item.id === parseInt(id)
        );
        urunFavori.quantity = 1;
        state.favorites.push(urunFavori);
        Swal.fire({
          title: "Başarılı",
          text: "İlgili ürün favorilere eklenmiştir",
          icon: "success",
        });
      } else {
        Swal.fire("Başarsız", "İlgili ürün favorilere eklenemedi", "warning");
      }
    },
    removeToFav: (state, action) => {
      let { id } = action.payload;
      let favorilerinOnSonHali = state.favorites.filter(
        (item) => item.id !== parseInt(id)
      );
      state.favorites = favorilerinOnSonHali;
    },
    //favorileri temizle
    clearFav: (state) => {
      state.favorites = []; // state içindeki favori arrayını temizlemiş oluyor
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchProducts.fulfilled, (state, action) => {
      /* console.log("Product Fetch Bitti") */
      state.products = action.payload.data.result;
      /* console.log(action.payload.data.result); */
    });
    builder.addCase(fetchCart.fulfilled, (state, action) => {
      /* console.log("Product Fetch Bitti") */
      state.carts = action.payload.data.result;
      /* console.log(action.payload.data.result); */
    });
  },
});

const productsReducer = productsSlice.reducer;
export default productsReducer;
