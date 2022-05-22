// import React, {useState, useEffect} from 'react'
// import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper} from '@mui/material';
// import { connect } from 'react-redux'
// import { getAllWalletsFromApi } from '../redux/operations'

// const Wallets = ({ allWallets, getAllWallets }) => {
//     const [wallets, setWallets] = useState(null)

//     useEffect(() => { getAllWallets() }, [])

//     // useEffect(() => {
//     //     if(wallets == null){
//     //         fetch('https://localhost:7149/api/Wallet/GetWallets')
//     //             .then(response => response.json())
//     //             .then(data => setWallets(data));
            
//     //     }
//     // },[])

//     return (
//         <TableContainer component={Paper}>
//             {console.log(allWallets)}
//             {wallets != null && console.log(wallets.items)}
//             <Table sx={{ minWidth: 650 }} aria-label="simple table">
//                 <TableHead>
//                 <TableRow>
//                     <TableCell>Name</TableCell>
//                     <TableCell>Ilość stock-ów</TableCell>
//                     <TableCell align="right">B</TableCell>
//                     <TableCell align="right">C</TableCell>
//                     <TableCell align="right">D</TableCell>
//                 </TableRow>
//                 </TableHead>
//                 <TableBody>
//                 {wallets != null && wallets.items.map((row) => (
//                     <TableRow
//                     key={row.id}
//                     sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
//                     >
//                     <TableCell component="th" scope="row">
//                         {row.name}
//                     </TableCell>
//                     <TableCell>{row.items.length}</TableCell>
//                     <TableCell align="right">{row.fat}</TableCell>
//                     <TableCell align="right">{row.carbs}</TableCell>
//                     <TableCell align="right">{row.protein}</TableCell>
//                     </TableRow>
//                 ))}
//                 </TableBody>
//             </Table>
//         </TableContainer>
//     )
// }

// const mapStateToProps = state => ({
//     allWallets: state.wallets
// })

// // mapDispatchToProps -, added the action methods
// const mapDispatchToProps = dispatch => ({
//     getAllWallets: () => dispatch(getAllWalletsFromApi()) 
// })

// export default connect(mapStateToProps, mapDispatchToProps) (Wallets);