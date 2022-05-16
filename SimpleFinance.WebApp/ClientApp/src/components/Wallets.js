import React, {useState, useEffect} from 'react'
import { Wallet } from './Wallet'

export const Wallets = () => {
    const [wallets, setWallets] = useState(null)

    useEffect(() => {
        if(wallets == null){
            fetch('https://localhost:7149/api/Wallet/GetWallets')
                .then(response => response.json())
                .then(data => setWallets(data));
            
        }
    },[])

    return (
        <div>
            <h3>Wallets</h3>
            {/* {wallets != null && console.log(wallets.items)}*/}
            {wallets != null && wallets.items.map((wallet) => {
                console.log(wallet.name)       
            })} 
            {wallets != null && wallets.items.map((wallet) => {
                <Wallet value={wallet} />       
            })} 
            {wallets != null && wallets.items.map((wallet) => {
                console.log(wallet.name) 
                     
            })}
        </div>
    )
}
