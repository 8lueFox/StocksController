export function fetchWallets(){
    return new Promise((resolve) =>{
        resolve(fetch('https://localhost:7149/api/Wallet/GetWallets')
            .then(response => response.json())
            .then(resp => resp))
        });
}