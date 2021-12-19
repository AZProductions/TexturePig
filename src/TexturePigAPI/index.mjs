import express from 'express';
import { createClient } from '@supabase/supabase-js'
const supabaseUrl = 'https://vneidrffkiqxdxwpwrzk.supabase.co'
const supabaseKey = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoic2VydmljZV9yb2xlIiwiaWF0IjoxNjM5OTA4OTU1LCJleHAiOjE5NTU0ODQ5NTV9.G45qH-0YOQgNt0ZmIgvjyC5Ue2HL6CFlgul_BYRo0fI';
const supabase = createClient(supabaseUrl, supabaseKey)
const app = express();
const PORT = 8080;
const VERSION = "/v1";
app.use( express.json() )

// supabase.from('pack')
//   .select('*')
//   .limit(5)
//   .then(console.log)

// app.get(VERSION+'/pack', (req, res) => 
// {
//     res.status(200).send({
//         name: 'Example',
//         version: '1.12'
//     })
// });

app.get(VERSION+'/pack/:id', (req, res) => 
{
    const { id } = req.params;
    if (!id)
    {
        res.status(420).send({ message: 'INVALID ARGUMENTS'})
    }
    const { data, error } = supabase
    .from('packs')
    .select('*')
    .eq('id', id).then(console.log);
    res.send({
        data: `${data}`
    })
});

app.listen(
    PORT,
    () => console.log(`Server Running: http://localhost:${PORT}`)
)