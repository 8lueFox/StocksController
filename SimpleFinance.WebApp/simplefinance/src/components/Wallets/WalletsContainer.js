import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, CircularProgress} from '@mui/material';
import React, { useEffect } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import {
    fetchAllWallets,
    selectWallets
}from './walletSlice'

export const WalletsContainer = () => {
    const wallets = useSelector(selectWallets)
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(fetchAllWallets())
    },[])

    return (
        <div>
            {console.log(wallets.wallets.status)}
            {wallets.wallets.status === 'loading' && <CircularProgress />}
            {wallets.wallets.status === 'idle' &&
            <TableContainer component={Paper}>
             <Table sx={{ minWidth: 650 }} aria-label="simple table">
                 <TableHead>
                 <TableRow>
                     <TableCell>Name</TableCell>
                     <TableCell>Ilość stock-ów</TableCell>
                     <TableCell align="right">B</TableCell>
                     <TableCell align="right">C</TableCell>
                     <TableCell align="right">D</TableCell>
                 </TableRow>
                 </TableHead>
                 <TableBody>
                 {wallets.wallets.wallets.length !== 0 && wallets.wallets.wallets.map((row) => (
                     <TableRow
                     key={row.id}
                     sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                     >
                     <TableCell component="th" scope="row">
                         {row.name}
                     </TableCell>
                     <TableCell>{row.items.length}</TableCell>
                     <TableCell align="right">{row.fat}</TableCell>
                     <TableCell align="right">{row.carbs}</TableCell>
                     <TableCell align="right">{row.protein}</TableCell>
                     </TableRow>
                 ))}
                 </TableBody>
             </Table>
         </TableContainer>}
        </div>
    )
}
