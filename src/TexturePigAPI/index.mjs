import express from 'express';
import { createClient } from '@supabase/supabase-js'
const supabaseUrl = 'https://vneidrffkiqxdxwpwrzk.supabase.co'
const supabaseKey = 'api-key';
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