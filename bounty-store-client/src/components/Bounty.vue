<template>
    <div class="card bounty">
        <div class="card-body">
            <h4 class="card-title">{{bounty.name}}</h4>
            <h5 class="card-subtitle mb-2 text-muted">Alive: <span class="text-success">${{bounty.aliveReward}}</span></h5>
            <h5 class="card-subtitle mb-2 text-muted">Dead: <span class="text-danger">${{bounty.deadReward}}</span></h5>
            <p class="card-text">{{bounty.description}}</p>

            <a v-if="!bounty.captured" href="#" class="card-link" @click.prevent="claimReward">Claim</a>
            <span v-else class="card-link text-muted">Claimed</span>

            <!-- Edit and delete -->
            <router-link :to="{ name: 'edit', params: { id: bounty.id } }" class="card-link">Edit</router-link>
            <a href="#" class="card-link text-danger" @click.prevent="deleteBounty">Delete</a>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import {apiEndpoint} from '../config';

export default {
    props: {
        bounty: {
            type: Object,
            required: true
        }
    },
    methods: {
        claimReward() {
            this.bounty.captured = true;
            axios.put(apiEndpoint + '/' + this.bounty.id, this.bounty).then(() => this.$emit('claimed', this.bounty));
        },
        deleteBounty() {
            axios.delete(apiEndpoint + '/' + this.bounty.id).then(() => this.$emit('deleted', this.bounty.id));
        }
    }
};
</script>

<style>
.bounty {
    background: url("../assets/paper_1.png");
    border-radius: 0;
    box-shadow: 5px 5px 5px;
}
</style>