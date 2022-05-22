import { configureStore } from "@reduxjs/toolkit"
import walletsReducer from "../components/Wallets/walletSlice"

export const store = configureStore({
    reducer: {
        wallets: walletsReducer
    }
})