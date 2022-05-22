import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { fetchWallets } from './walletsApi'

const initialState = {
    wallets: [],
    status: 'idle'
}

export const fetchAllWallets = createAsyncThunk(
  'wallet/fetchAllWallets',
  async() => {
      return await fetchWallets()
  }  
);

export const walletSlice = createSlice({
    name: 'wallet',
    initialState,
    reducers:{

    },
    extraReducers: (buider) => {
        buider
           .addCase(fetchAllWallets.pending, (state) => {
               state.status = 'loading';
           })
           .addCase(fetchAllWallets.fulfilled, (state, action) => {
               state.status = 'idle'
               state.wallets = action.payload.items
           })
    }
})

export const { } = walletSlice.actions;

export const selectWallets = (state) => state

export default walletSlice.reducer;